using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;

using Aurora.Settings;
using Aurora.Utils;

namespace Aurora.Devices.SteelSeries
{
    public partial class SteelSeriesDevice : Device
    {
        TimeSpan updateTime = TimeSpan.Zero;
        object lock_obj = new object();

        public VariableRegistry GetRegisteredVariables()
        {
            return new VariableRegistry();
        }

        public string GetDeviceName() => "SteelSeries";

        public string GetDeviceDetails() => IsInitialized() ? GetDeviceName() + ": Connected" : GetDeviceName() + ": Not initialized";

        public string GetDeviceUpdatePerformance()
        {
            return (IsInitialized() ? getDeviceUpdateTime() + " ms" : "");
        }

        private string getDeviceUpdateTime()
        {
            return updateTime.TotalMilliseconds > 1000 ? "Restart SteelSeries Engine it has not responded for over 1000" : ((int)updateTime.TotalMilliseconds).ToString();
        }

        public bool Initialize()
        {
            lock (lock_obj)
            {
                try
                {
                    if (Global.Configuration.steelseries_first_time)
                    {
                        System.Windows.Application.Current.Dispatcher?.Invoke(() =>
                        {
                            SteelSeriesInstallInstructions instructions = new SteelSeriesInstallInstructions();
                            instructions.ShowDialog();
                        });
                        Global.Configuration.steelseries_first_time = false;
                        ConfigManager.Save(Global.Configuration);
                    }
                    if (!baseObject.ContainsKey("game"))
                    {
                        baseObject.Add("game", "PROJECTAURORA");
                        baseColorObject.Add("game", baseObject["game"]);
                    }
                    client = new HttpClient {Timeout = TimeSpan.FromSeconds(30)};
                    loadCoreProps();
                    return true;
                }
                catch (Exception e)
                {
                    Global.logger.Error("SteelSeries SDK could not be initialized: " + e);
                    return false;
                }
            }
        }

        public void Shutdown()
        {
            lock (lock_obj)
            {
                pingTaskTokenSource.Cancel();
                client?.Dispose();
                loadedLisp = false;
            }
        }

        public void Reset()
        {
        }

        public bool Reconnect() => true;

        public bool IsInitialized() => loadedLisp;

        public bool IsConnected() => loadedLisp;

        public bool IsKeyboardConnected() => IsConnected();

        public bool IsPeripheralConnected() => IsConnected();

        public bool UpdateDevice(Dictionary<DeviceKeys, Color> keyColors, DoWorkEventArgs e, bool forced = false)
        {
            foreach (var (key, color) in keyColors)
            {
                if (TryGetHid(key, out var hid))
                {
                    setKeyboardLed(hid, color);
                }
            }
            return true;
        }

        public bool UpdateDevice(DeviceColorComposition colorComposition, DoWorkEventArgs e, bool forced = false)
        {
            var tmpTime = DateTime.Now;
            var keyColors = colorComposition.keyColors.ToDictionary(t => t.Key, t => ColorUtils.MultiplyColorByScalar(t.Value, t.Value.A / 255D));
            if (!Global.Configuration.devices_disable_mouse || !Global.Configuration.devices_disable_headset)
            {
                if (!keyColors.ContainsKey(DeviceKeys.Peripheral))
                {
                    var mousePad = keyColors.Where(t => t.Key >= DeviceKeys.MOUSEPADLIGHT1 && t.Key <= DeviceKeys.MOUSEPADLIGHT12).Select(t => t.Value).ToArray();
                    var tmpmouse = new List<Color> { keyColors[DeviceKeys.Peripheral_Logo], keyColors[DeviceKeys.Peripheral_ScrollWheel]};
                    var mouse = tmpmouse.ToArray();
                    tmpmouse.Clear();
                    var monitor = keyColors.Where(t => t.Key >= DeviceKeys.MONITORLIGHT1 && t.Key <= DeviceKeys.MONITORLIGHT103).Select(t => t.Value).ToArray();
                    if (mouse.Length <= 1)
                        setMouse(keyColors[DeviceKeys.Peripheral_Logo]);
                    else
                    {
                        setLogo(keyColors[DeviceKeys.Peripheral_Logo]);
                        setWheel(keyColors[DeviceKeys.Peripheral_ScrollWheel]);
                        if (mouse.Length == 8)
                            setEightZone(mouse);
                    }
                    if (mousePad.Length == 2)
                        setTwoZone(mousePad);
                    else
                        setTwelveZone(mousePad);
                    if (monitor.Length == 103)
                        setHundredThreeZone(monitor);
                }
                else
                    setGeneric(keyColors[DeviceKeys.Peripheral]);
            }
            if (!Global.Configuration.devices_disable_keyboard)
            {
                UpdateDevice(keyColors, e, forced);
            }
            sendLighting();
            updateTime = DateTime.Now - tmpTime;
            return true;
        }
    }
}
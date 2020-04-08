using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
            Shutdown();
            lock (lock_obj)
            {
                Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\SteelSeries\SteelSeries Engine 3\SteelSeries Engine 3.lnk");
                Task.Delay(15000).GetAwaiter().GetResult();
            }
            Initialize();
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
            dataColorObject.RemoveAll();
            if (!Global.Configuration.devices_disable_mouse || !Global.Configuration.devices_disable_headset)
            {
                if (!keyColors.ContainsKey(DeviceKeys.Peripheral))
                {
                    var mousePad = keyColors.Where(t => t.Key >= DeviceKeys.MOUSEPADLIGHT1 && t.Key <= DeviceKeys.MOUSEPADLIGHT12).Select(t => t.Value).ToArray();
                    var mouse = new List<Color> { keyColors[DeviceKeys.Peripheral_Logo], keyColors[DeviceKeys.Peripheral_ScrollWheel]};
                    mouse.AddRange(keyColors.Where(t => t.Key <= DeviceKeys.MOUSELIGHT1 && t.Key >= DeviceKeys.MOUSELIGHT6).Select(t => t.Value));
                    setOneZone(keyColors[DeviceKeys.Peripheral_Logo]);
                    if (mouse.Count != 1)
                        setMouse(keyColors[DeviceKeys.Peripheral_Logo]);
                    else
                    {
                        setLogo(keyColors[DeviceKeys.Peripheral_Logo]);
                        setWheel(keyColors[DeviceKeys.Peripheral_ScrollWheel]);
                        if (mouse.Count == 8)
                            setEightZone(mouse.ToArray());
                    }
                    if (mousePad.Length == 2)
                        setTwoZone(mousePad);
                    else
                        setTwelveZone(mousePad);
                    if (keyColors.Count(t => t.Key >= DeviceKeys.MONITORLIGHT1 && t.Key <= DeviceKeys.MONITORLIGHT103) == 103)
                        setHundredThreeZone(keyColors.Where(t => t.Key >= DeviceKeys.MONITORLIGHT1 && t.Key <= DeviceKeys.MONITORLIGHT103).Select(t => t.Value).ToArray());
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
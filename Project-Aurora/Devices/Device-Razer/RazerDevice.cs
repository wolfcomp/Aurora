using Aurora.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Corale.Colore.Core;
using Corale.Colore.Razer;
using Device = Aurora.Devices.Device;
using KeyboardCustom = Corale.Colore.Razer.Keyboard.Effects.Custom;
using MousepadCustom = Corale.Colore.Razer.Mousepad.Effects.Custom;
using MouseCustom = Corale.Colore.Razer.Mouse.Effects.CustomGrid;
using HeadsetCustom = Corale.Colore.Razer.Headset.Effects.Static;
using KeypadCustom = Corale.Colore.Razer.Keypad.Effects.Custom;
using ChromalinkCustom = Corale.Colore.Razer.ChromaLink.Effects.Custom;

namespace Device_Razer
{
    public class RazerDevice : Device
    {
        protected override string DeviceName => "Razer";

        private IChroma chroma;
        
        private KeyboardCustom keyboard = KeyboardCustom.Create();
        private MousepadCustom mousepad = MousepadCustom.Create();
        private MouseCustom mouse =  MouseCustom.Create();
        private HeadsetCustom headset = new HeadsetCustom(ToColore(System.Drawing.Color.Black));
        private KeypadCustom keypad = KeypadCustom.Create();
        private ChromalinkCustom chromalink = ChromalinkCustom.Create();

        private List<string> deviceNames;

        public override bool Initialize()
        {
            try
            {
                //hack
                chroma = Chroma.Instance;
                chroma.Initialize();

                DetectDevices();

                isInitialized = true;
                return true;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                isInitialized = false;
                return false;
            }
        }

        public override string GetDeviceDetails()
        {
            if (isInitialized)
            {
                string devString = DeviceName + ": ";
                devString += "Connected";

                if (deviceNames.Any())
                    devString += ": " + string.Join(", ", deviceNames);
                else
                    devString += ": no devices detected";

                return devString;
            }
            else
            {
                return DeviceName + ": Not initialized";
            }
        }

        public override void Shutdown()
        {
            try
            {
                chroma.SetAll(new Color(0, 0, 0));
                chroma.Uninitialize();
                isInitialized = false;
            }
            catch (Exception e)
            {
                LogError(e.Message);
            }
        }

        ~RazerDevice()
        {
            Shutdown();
        }

        public override bool UpdateDevice(Dictionary<DeviceKeys, System.Drawing.Color> keyColors, DoWorkEventArgs e, bool forced = false)
        {
            foreach (var key in keyColors)
            {
                var color = ToColore(key.Value);
                if (RazerMappings.keyboardDictionary.TryGetValue(key.Key, out var kbIndex))
                    keyboard[kbIndex] = color;

                if (RazerMappings.mouseDictionary.TryGetValue(key.Key, out var mouseIndex))
                    mouse[mouseIndex] = color;

                if (RazerMappings.mousepadDictionary.TryGetValue(key.Key, out var mousepadIndex))
                    mousepad[mousepadIndex] = color;

                //if (RazerMappings.headsetDictionary.TryGetValue(key.Key, out var headsetIndex))
                //    headset[headsetIndex] = ToColore(key.Value);

                if (RazerMappings.chromalinkDictionary.TryGetValue(key.Key, out var chromalinkIndex))
                    chromalink[chromalinkIndex] = color;
            }
            UpdateAll();
            return true;
        }

        private static Color ToColore(System.Drawing.Color source) => new Color(source.R, source.G, source.B);

        private void DetectDevices()
        {
            //get all devices from colore, with the respective names and Guids
            var k = typeof(Devices).GetFields();
            IEnumerable<(string Name, Guid Guid)> DeviceGuids = k.Select(f => (f.Name, (Guid)f.GetValue(null)));

            deviceNames = new List<string>();

            foreach (var device in DeviceGuids.Where(d => d.Name != "Razer Core Chroma"))//somehow this device is unsupported, can't query it
            {
                try
                {
                    var devInfo = Chroma.Instance.Query(device.Guid);
                    if (devInfo.Connected)
                    {
                        deviceNames.Add(device.Name);
                    }
                }
                catch (Exception e)
                {
                    //if ((e.InnerException is Colore.Native.NativeCallException) && (e.InnerException as Colore.Native.NativeCallException).Result.Value == 1167)
                    //{
                    //    //Global.logger.Info("device NOT connected: " + device.Name);
                    //}
                    //else
                    //{
                    //    //Global.logger.Info(e);
                    //}
                }
            }
        }

        private void UpdateAll()
        {
            chroma.Keyboard.SetCustom(keyboard);
            chroma.Mouse.SetGrid(mouse);
            chroma.Headset.SetStatic(headset);
            chroma.Mousepad.SetCustom(mousepad);
            chroma.Keypad.SetCustom(keypad);
            chroma.ChromaLink.SetCustom(chromalink);
        }
    }
}

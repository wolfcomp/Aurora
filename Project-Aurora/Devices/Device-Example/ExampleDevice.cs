﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Devices;
using Aurora.Settings;

namespace Device_Example
{
    public class ExampleDevice : Aurora.Devices.Device
    {
        protected override string DeviceName => "Example Device";

        public override bool Initialize()
        {
            LogInfo("Initializing example!");

            return isInitialized = true;
        }

        public override void Shutdown()
        {
            LogInfo("Shutting down example!");

            isInitialized = false;
        }

        public override bool UpdateDevice(Dictionary<DeviceKeys, System.Drawing.Color> keyColors, DoWorkEventArgs e, bool forced = false)
        {
            //Log("Updating!");
            return true;
        }

        protected override void RegisterVariables(VariableRegistry local)
        {
            local.Register($"{DeviceName}_devicekey", DeviceKeys.Peripheral, "Key to Use", DeviceKeys.MOUSEPADLIGHT15, DeviceKeys.Peripheral_Logo);
        }
    }
}

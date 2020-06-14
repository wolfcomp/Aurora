using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Devices;

namespace Device_Gigabyte
{
    public class GigabyteDevice : Device
    {
        protected override string DeviceName => "Gigabyte";

        public override bool Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Shutdown()
        {
            throw new NotImplementedException();
        }

        public override bool UpdateDevice(Dictionary<DeviceKeys, Color> keyColors, DoWorkEventArgs e, bool forced = false)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Profiles.FFXIV.Layers;
using Aurora.Settings;
using Aurora.Settings.Layers;

namespace Aurora.Profiles.FFXIV
{
    public class FFXIVProfile : ApplicationProfile
    {
        public FFXIVProfile() : base()
        {
            
        }

        public override void Reset()
        {
            base.Reset();
            Layers = new ObservableCollection<Layer>
            {
                new Layer("Action Layer", new FFXIVActionLayerHandler())
            };
        }
    }
}

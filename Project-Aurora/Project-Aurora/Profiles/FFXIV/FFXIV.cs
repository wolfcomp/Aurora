using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Profiles.EliteDangerous;
using Aurora.Profiles.FFXIV.Layers;
using Aurora.Settings;

namespace Aurora.Profiles.FFXIV
{
    public class FFXIV : Application
    {
        public FFXIV() : base(new LightEventConfig
        {
            Name = "FFXIV",
            AppID = "39210",
            ID = "ffxiv",
            Event = new GameEvent_Generic(),
            IconURI = "Resources/ffxiv_48x48.png",
            GameStateType = typeof(GSI.GameState_FFXIV),
            ProfileType = typeof(FFXIVProfile),
            SettingsType = typeof(FirstTimeApplicationSettings),
            OverviewControlType = typeof(Control_FFXIV),
            ProcessNames = new []{ "ffxiv_dx11.exe" }
        })
        {
            var extra = new List<LayerHandlerEntry>
            {
                new LayerHandlerEntry("FFXIVActionsLayer", "FFXIV Actions Layer", typeof(FFXIVActionLayerHandler))
            };

            Global.LightingStateManager.RegisterLayerHandlers(extra, false);

            foreach (var entry in extra)
            {
                Config.ExtraAvailableLayers.Add(entry.Key);
            }
        }
    }
}

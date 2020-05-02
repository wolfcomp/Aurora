﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Aurora.Devices;
using Aurora.EffectsEngine;
using Aurora.Profiles.FFXIV.GSI;
using Aurora.Settings.Layers;
using Newtonsoft.Json;

namespace Aurora.Profiles.FFXIV.Layers
{
    public class KeyBindLayerHandlerProperties : LayerHandlerProperties<KeyBindLayerHandlerProperties>
    {
        public bool _Ignore { get; set; }

        [JsonIgnore]
        public bool Ignore
        {
            get => _Ignore;
        }

        public KeyBindLayerHandlerProperties() : base() { }

        public KeyBindLayerHandlerProperties(bool assign_default = false) : base(assign_default) { }
    }

    public class FFXIVKeyBindLayerHandler : LayerHandler<KeyBindLayerHandlerProperties>
    {
        public FFXIVKeyBindLayerHandler() : base()
        {
            _ID = "FFXIVKeyBindLayer";
        }

        protected override UserControl CreateControl()
        {
            return new Control_FFXIVKeyBindLayerHandler(this);
        }

        private static List<DeviceKeys> modifList = new List<DeviceKeys> { DeviceKeys.LEFT_ALT, DeviceKeys.LEFT_CONTROL, DeviceKeys.LEFT_SHIFT, DeviceKeys.RIGHT_ALT, DeviceKeys.RIGHT_CONTROL, DeviceKeys.RIGHT_SHIFT };

        public override EffectLayer Render(IGameState gamestate)
        {
            var layer = new EffectLayer("FFXIV - Action Layer");
            layer.Fill(Color.Transparent);
            if (gamestate is GameState_FFXIV ffxiv && ffxiv.KeyBinds.Any())
            {
                List<DeviceKeys> modifs = new List<DeviceKeys>();
                var recordedKeys = Global.InputEvents;
                var modif = new List<DeviceKeys>();
                if (recordedKeys.Alt)
                {
                    modif.AddRange(new [] { DeviceKeys.LEFT_ALT, DeviceKeys.LEFT_SHIFT });
                }
                if (recordedKeys.Control)
                {
                    modif.AddRange(new [] { DeviceKeys.LEFT_CONTROL, DeviceKeys.RIGHT_CONTROL });
                }
                if (recordedKeys.Shift)
                {
                    modif.AddRange(new [] { DeviceKeys.LEFT_SHIFT, DeviceKeys.RIGHT_SHIFT });
                }
                if (!recordedKeys.Shift && !recordedKeys.Control && !recordedKeys.Alt)
                {
                    modif.AddRange(new [] { DeviceKeys.NONE });
                }
                foreach (var keyBind in ffxiv.KeyBinds.Where(t => t.Key != DeviceKeys.NONE && t.KeyMod.All(f => modif.Contains(f)) && (!modif.Any() || modif.All(f => t.KeyMod.Contains(f))) && (!Properties.Ignore || !t.Command.Contains("PERFORMANCE_MODE"))))
                {
                    layer.Set(keyBind.Key, Properties.PrimaryColor);
                    if (keyBind.KeyMod[0] != DeviceKeys.NONE)
                    {
                        modifs.AddRange(keyBind.KeyMod);
                    }
                }
                layer.Set(modifs.ToArray(), Properties.PrimaryColor);
            }
            return layer;
        }

        public override void SetApplication(Application profile)
        {
            (Control as Control_FFXIVKeyBindLayerHandler).SetProfile(profile);
            base.SetApplication(profile);
        }
    }
}
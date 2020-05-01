using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Profiles.FFXIV.GSI
{
    public class GameState_FFXIV : GameState<GameState_FFXIV>
    {
        private FFXIVActionNode _Actions { get; set; } = new FFXIVActionNode();

        public FFXIVActionNode Actions
        {
            get
            {
                if (_ParsedData.ContainsKey("actions"))
                {
                    _Actions.Clear();
                    var actionsList = _ParsedData["actions"].ToObject<byte[]>();
                    var offset = 0;
                    while (actionsList.Length > offset)
                    {
                        _Actions.Add(new FFXIVAction(actionsList, offset, out offset));
                    }
                }
                return _Actions;
            }
        }

        public GameState_FFXIV() : base()
        {

        }

        public GameState_FFXIV(string json) : base(json)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is GameState_FFXIV ffxiv)
            {
                ffxiv.Actions.Equals(Actions);
            }
            return base.Equals(obj);
        }
    }
}

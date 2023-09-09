using Exiled.API.Interfaces;
using System.ComponentModel;

namespace killpopup
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        [Description("Use the %player% placeholder")]
        public string KillMessage { get; set; } = "<b>Killed <color=red>%player%</color></b>";

        [Description("Duration of the hint")]
        public float HintDuration { get; set; } = 5.0F;

        [Description("Hitmarker hint. %damage% - damage, %remaining% - target's remaining hp")]
        public string HitmarkerHint { get; set; } = "<color=red>%damage%</color> | <color=blue>%remaining%</color>";

        [Description("Duration of the hitmarker hint (0.2 is recommended)")]
        public float HitmarkerDuration { get; set; } = 0.2F;
    }
}
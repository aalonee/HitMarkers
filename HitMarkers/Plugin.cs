using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using Exiled.Events.Commands.Reload;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Events;

namespace killpopup
{
    public sealed class Plugin : Plugin<Config>
    {
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override string Name { get; } = "Hitmarkers";

        public override string Author { get; } = "alone";

        public override string Prefix { get; } = "Hitmarkers";

        public override void OnEnabled()
        {
            base.OnEnabled();   
            Exiled.Events.Handlers.Player.Dying += DyingEvent;
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.Dying -= DyingEvent;
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker != null && ev.Player != null && ev.Attacker != ev.Player)
            {
                ev.Attacker.ShowHint(Config.HitmarkerHint.Replace("%damage%", Math.Round(ev.Amount).ToString()).Replace("%remaining%", (Math.Round(ev.Player.Health) - Math.Round(ev.Amount)).ToString()), Config.HitmarkerDuration);
            }
        }

        public void DyingEvent(DyingEventArgs ev)
        {
            if (ev.Attacker != null && ev.Player != null && ev.Attacker != ev.Player)
            {
                ev.Attacker.ShowHint(Config.KillMessage.Replace("%player%", ev.Player.Nickname), Config.HintDuration);
            }
        }
    }
}
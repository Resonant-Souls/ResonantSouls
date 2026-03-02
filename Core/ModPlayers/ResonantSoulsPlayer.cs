using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace ResonantSouls.Core.ModPlayers
{
    public class ResonantSoulsPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            if (ResonantSoulsClientConfig.Instance?.WarningNotification ?? false)
            {
                Main.NewText(Language.GetTextValue($"Mods.{Mod.Name}.Message.WarningNotification"), Color.Red);
            }
        }
    }
}
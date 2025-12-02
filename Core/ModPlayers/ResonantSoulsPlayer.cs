using Terraria.Localization;

namespace ResonantSouls.Core.ModPlayers
{
    public class ResonantSoulsPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            if (ResonantSoulsClientConfig.Instance.WarningNotification)
            {
                Main.NewText(Language.GetTextValue($"Mods.{Mod.Name}.Message.WarningNotification1"), Color.Red);
                Main.NewText(Language.GetTextValue($"Mods.{Mod.Name}.Message.WarningNotification2"), Color.Red);
                Main.NewText(Language.GetTextValue($"Mods.{Mod.Name}.Message.WarningNotification3"), Color.Red);
                Main.NewText(Language.GetTextValue($"Mods.{Mod.Name}.Message.WarningNotification4"), Color.Red);
                Main.NewText(Language.GetTextValue($"Mods.{Mod.Name}.Message.WarningNotification5"), Color.Red);
                Main.NewText(Language.GetTextValue($"Mods.{Mod.Name}.Message.WarningNotification6"), Color.Red);
            }
        }
    }
}
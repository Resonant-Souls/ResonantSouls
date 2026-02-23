using FargowiltasSouls.Content.Items.Summons;
using Terraria.Localization;

namespace ResonantSouls.Content.Items.Consumables.Summons
{
    public class SigilOfResonance : SigilOfChampions
    {
        public override string Texture => $"{Mod.Name}/Assets/Textures/Content/Items/Summons/SigilOfResonance";
        private static void PrintChampMessage(string key)
        {
            Main.NewText(Language.GetTextValue($"Mods.ResonantSouls.Items.SigilOfResonance.Message.{key}"), new Color(175, 75, 255));
        }
        public override bool? UseItem(Player player)
        {
            /*
            if (ModCompatibility.SpiritMod.Loaded)
            {
                ModContent.TryFind(ModCompatibility.SpiritMod.Name, "BriarSurfaceBiome", out ModBiome briarBiome);
                if (player.InModBiome(briarBiome))
                {
                    if (player.altFunctionUse == 2)
                        PrintChampMessage("Etheriality");
                    else
                        FargoSoulsUtil.SpawnBossNetcoded(player, ModContent.Find<ModNPC>("EtherialityChampion").Type);
                }
                return true;
            }
            */
            if (player.altFunctionUse == 2)
                PrintChampMessage("Nothing");

            return true;
        }
    }
}
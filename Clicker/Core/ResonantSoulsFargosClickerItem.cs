using FargoClickers;
using FargoClickers.Content.Items.Accessories;
using FargowiltasSouls.Content.Items;
using ResonantSouls.Content.Items.Accessories.Souls;
using Terraria.Localization;

namespace ResonantSouls.Clicker.Core
{
    [JITWhenModsEnabled(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    [ExtendsFromMod(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    public class FargoClickersGlobalItem : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsFargosClickerConfig.Instance.ClickerCompat;
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            bool Microverse = item.type == ModContent.ItemType<MicroverseSoul>() || item.type == ModContent.ItemType<EternitySoul>();
            bool Universe = item.type == ModContent.ItemType<UniverseSoul>() || item.type == ModContent.ItemType<EternitySoul>();

            if (Microverse)
            {
                ForceOfMatrix.UpdateForceOfMatrix(player, item);
            }
            if (Universe)
            {
                player.Clicker().clickerRadius += 2f;
                player.Clicker().clickerBonusPercent += 0.2f;
                MasterPlayerSoul.UpdateMasterPlayerSoulAccessories(item, player, hideVisual);
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");

            if (item.type == ModContent.ItemType<MicroverseSoul>() && !item.social)
            {
                int Forces = tooltips.FindIndex(line => line.Name == "Forces");
                tooltips[Forces].Text = "[i:FargoClickers/ForceOfMatrix]" + tooltips[Forces].Text;
            }

            // How Fargo's DLC does it.

            if (item.type == ModContent.ItemType<UniverseSoul>() && !item.social)
            {
                if (SoulsItem.IsNotRuminating(item))
                {
                    int Conjurist = tooltips.FindIndex(t => t.Text.Contains("[i:FargowiltasSouls/ConjuristsSoul]"));
                    tooltips[Conjurist].Text = tooltips[Conjurist].Text.Replace("[i:FargowiltasSouls/ConjuristsSoul]", "[i:FargowiltasSouls/ConjuristsSoul]" + "[i:FargoClickers/MasterPlayerSoul]");
                }
                else
                {
                    string MasterPlayerText = "[i:ClickerClass/AimbotModule]" + " " + Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.MasterPlayer");
                    var lines = tooltips[tooltip0].Text.Split("\n").ToList();
                    lines.Insert(lines.Count - 1, MasterPlayerText);
                    tooltips[tooltip0].Text = string.Join("\n", lines);
                }
            }
        }
    }
}
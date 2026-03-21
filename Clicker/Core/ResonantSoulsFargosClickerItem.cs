using System.Collections.Generic;
using System.Linq;
using FargoClickers;
using FargoClickers.Content.Items.Accessories;
using FargowiltasSouls.Content.Items;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using ResonantSouls.Content.Items.Accessories.Souls;
using Terraria.Localization;

namespace ResonantSouls.Clicker.Core
{
    [JITWhenModsEnabled(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    [ExtendsFromMod(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    public class FargoClickersGlobalItem : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsFargosClickerConfig.ClickerCompat;
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            bool Microverse = item.type == ModContent.ItemType<MicroverseSoul>() || item.type == ModContent.ItemType<EternitySoul>();
            bool Universe = item.type == ModContent.ItemType<UniverseSoul>() || item.type == ModContent.ItemType<EternitySoul>();

            if (Microverse && ModCompatibility.AnyMicroverse)
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
            int Tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");
            const string key = "Mods.ResonantSouls.Items.";
            if (item.type == ModContent.ItemType<UniverseSoul>() && !item.social)
            {
                if (SoulsItem.IsNotRuminating(item))
                {
                    const string conjurists = "[i:FargowiltasSouls/ConjuristsSoul]";
                    int extraeff = tooltips.FindIndex(t => t.Text.Contains(conjurists));
                    tooltips[extraeff].Text = tooltips[extraeff].Text.Replace(conjurists, conjurists + "[i:FargoClickers/MasterPlayerSoul]");
                }
                else
                {
                    // How Fargo's DLC does it
                    var lines = tooltips[Tooltip0].Text.Split("\n").ToList();
                    lines.Insert(lines.Count - 1, Language.GetTextValue(key + "AddedEffects.ClickerUniverse"));
                    tooltips[Tooltip0].Text = string.Join("\n", lines);
                }
            }
        }
    }
}
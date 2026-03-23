using System.Collections.Generic;
using System.Linq;
using FargowiltasSouls.Content.Items;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Armor.Eridanus;
using FargowiltasSouls.Content.Items.Armor.Eternal;
using FargowiltasSouls.Content.Items.Armor.Gaia;
using FargowiltasSouls.Content.Items.Armor.Nekomi;
using FargowiltasSouls.Content.Items.Armor.Styx;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using OrchidMod;
using ResonantSouls.OrchidMod.Souls;
using Terraria.Localization;

namespace ResonantSouls.OrchidMod.Core
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            bool Universe = item.type == ModContent.ItemType<UniverseSoul>() || item.type == ModContent.ItemType<EternitySoul>();
            OrchidGuardian mp = player.GetModPlayer<OrchidGuardian>();

            if (Universe)
            {
                player.AddEffect<GuardianEffect>(item);
            }
            else if (item.type == ModContent.ItemType<StyxCrown>())
            {
                mp.GuardianGuardMax += 3;
                mp.GuardianSlamMax += 3;
            }
            else if (item.type == ModContent.ItemType<EternalFlame>())
            {
                mp.GuardianGuardMax += 6;
                mp.GuardianSlamMax += 6;
            }
            else if (item.type == ModContent.ItemType<NekomiHood>())
            {
                mp.GuardianGuardMax += 1;
            }
            else if (item.type == ModContent.ItemType<NekomiHoodie>())
            {
                mp.GuardianSlamMax += 1;
            }
            else if (item.type == ModContent.ItemType<GaiaHelmet>())
            {
                mp.GuardianGuardMax += 1;
                mp.GuardianSlamMax += 1;
            }
            else if (item.type == ModContent.ItemType<GaiaPlate>())
            {
                mp.GuardianGuardMax += 1;
                mp.GuardianSlamMax += 1;
            }
            else if (item.type == ModContent.ItemType<EridanusLegwear>())
            {
                mp.GuardianGuardMax += 2;
                mp.GuardianSlamMax += 2;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int Tooltip = tooltips.FindLastIndex(t => t.Name.StartsWith("Tooltip") && t.Mod == "Terraria");
            const string key = "Mods.ResonantSouls.Items.";
            int Tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");

            var lines = tooltips[Tooltip].Text.Split("\n").ToList();

            if (item.type == ModContent.ItemType<UniverseSoul>() && !item.social)
            {
                if (SoulsItem.IsNotRuminating(item))
                {
                    const string conjurists = "[i:FargowiltasSouls/ConjuristsSoul]";
                    int extraeff = tooltips.FindIndex(t => t.Text.Contains(conjurists));
                    tooltips[extraeff].Text = tooltips[extraeff].Text.Replace(conjurists, conjurists + "[i:ResonantSouls/GuardiansSoul]");
                }
                else
                {
                    var linesU = tooltips[Tooltip0].Text.Split("\n").ToList();
                    linesU.Insert(linesU.Count - 1, Language.GetTextValue(key + "AddedEffects.GuardianUniverse"));
                    tooltips[Tooltip0].Text = string.Join("\n", linesU);
                }
            }
            else if (item.type == ModContent.ItemType<EternalFlame>())
            {
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 6));
                tooltips[Tooltip].Text = string.Join("\n", lines);
            }
            else if (item.type == ModContent.ItemType<StyxCrown>())
            {
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 3));
                tooltips[Tooltip].Text = string.Join("\n", lines);
            }
            else if (item.type == ModContent.ItemType<NekomiHood>())
            {
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuards", 1));
                tooltips[Tooltip].Text = string.Join("\n", lines);
            }
            else if (item.type == ModContent.ItemType<NekomiHoodie>())
            {
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseSlams", 1));
                tooltips[Tooltip].Text = string.Join("\n", lines);
            }
            else if (item.type == ModContent.ItemType<GaiaHelmet>())
            {
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 3));
                tooltips[Tooltip].Text = string.Join("\n", lines);
            }
            else if (item.type == ModContent.ItemType<GaiaPlate>())
            {
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 3));
                tooltips[Tooltip].Text = string.Join("\n", lines);
            }
            else if (item.type == ModContent.ItemType<EridanusLegwear>())
            {
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 2));
                tooltips[Tooltip].Text = string.Join("\n", lines);
            }

        }
    }
}
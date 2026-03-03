using System.Collections.Generic;
using System.Linq;
using FargowiltasSouls.Content.Items;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using ResonantSouls.BombusApis.Souls;
using Terraria.Localization;

namespace ResonantSouls.BombusApis.Core
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            bool Universe = item.type == ModContent.ItemType<UniverseSoul>() || item.type == ModContent.ItemType<EternitySoul>();

            if (ResonantSoulsBombusApisConfig.Instance?.Enchantments ?? false)
            {
                if (Universe)
                {
                    player.AddEffect<ApiaristEffect>(item);
                }
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int Tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");
            string key = "Mods.ResonantSouls.Items.";
            if (item.type == ModContent.ItemType<UniverseSoul>() && !item.social)
            {
                if (SoulsItem.IsNotRuminating(item))
                {
                    const string conjurists = "[i:FargowiltasSouls/ConjuristsSoul]";
                    int extraeff = tooltips.FindIndex(t => t.Text.Contains(conjurists));
                    tooltips[extraeff].Text = tooltips[extraeff].Text.Replace(conjurists, conjurists + "[i:ResonantSouls/ApiaristsSoul]");
                }
                else
                {
                    // How Fargo's DLC does it
                    var lines = tooltips[Tooltip0].Text.Split("\n").ToList();
                    lines.Insert(lines.Count - 1, Language.GetTextValue(key + "AddedEffects.BombusUniverse"));
                    tooltips[Tooltip0].Text = string.Join("\n", lines);
                }
            }
        }
    }
}
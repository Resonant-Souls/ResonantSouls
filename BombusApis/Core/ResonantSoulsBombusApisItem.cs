using System.Text.RegularExpressions;
using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Souls;
using Terraria.Localization;

namespace ResonantSouls.BombusApis.Core
{

    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisPlayer : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (ResonantSoulsBombusApisConfig.Instance.Enchantments)
            {
                if (item.type == ModContent.ItemType<UniverseSoul>() || item.type == ModContent.ItemType<EternitySoul>())
                {

                }
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.ModItem is null)
                return;

            if (item.ModItem is UniverseSoul)
            {
                foreach (var line in tooltips)
                {
                    if (line.Text.Contains("[i:FargowiltasSouls/ConjuristsSoul]"))
                    {
                        line.Text = line.Text.Replace("[i:FargowiltasSouls/ConjuristsSoul]", "[i:FargowiltasSouls/ConjuristsSoul][i:ResonantSouls/ApiaristsSoul]");
                    }
                }
            }
        }
    }
}
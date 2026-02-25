using FargowiltasSouls.Content.Items;
using ResonantSouls.BombusApis.Souls;
using ResonantSouls.Content.Items.Accessories.Souls;

namespace ResonantSouls.BombusApis.Core
{

    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            bool Universe = item.type == ModContent.ItemType<UniverseSoul>() || item.type == ModContent.ItemType<EternitySoul>();

            if (Universe)
            {
                player.AddEffect<ApiaristSoulThing>(item);
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ModContent.ItemType<MicroverseSoul>() && !item.social)
            {
                int Forces = tooltips.FindIndex(line => line.Name == "Forces");
                tooltips[Forces].Text = "[i:ResonantSouls/PollinationForce]" + tooltips[Forces].Text;
            }

            // How Fargo's DLC does it.
            if (item.type == ModContent.ItemType<UniverseSoul>() && !item.social)
            {
                if (SoulsItem.IsNotRuminating(item))
                {
                    int Conjurist = tooltips.FindIndex(t => t.Text.Contains("[i:FargowiltasSouls/ConjuristsSoul]"));
                    tooltips[Conjurist].Text = tooltips[Conjurist].Text.Replace("[i:FargowiltasSouls/ConjuristsSoul]", "[i:FargowiltasSouls/ConjuristsSoul]" + "[i:ResonantSouls/ApiaristsSoul]");
                }
            }
        }
    }
}
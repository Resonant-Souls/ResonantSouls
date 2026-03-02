using System.Collections.Generic;
using System.Linq;
using FargowiltasSouls.Content.Items;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using ResonantSouls.BombusApis.Souls;
using ResonantSouls.Content.Items.Accessories.Souls;
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
            int tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");

            if (ResonantSoulsBombusApisConfig.Instance?.Enchantments ?? false)
            {
                if (item.type == ModContent.ItemType<MicroverseSoul>() && !item.social)
                {
                    if (SoulsItem.IsNotRuminating(item))
                    {
                        int Forces = tooltips.FindIndex(line => line.Name == "Forces");
                        tooltips[Forces].Text = "[i:ResonantSouls/PollinationForce]" + tooltips[Forces].Text;
                    }
                    else
                    {
                        TooltipLine clickerLine = new(Mod, "BombusEffect", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.Bombus"));
                        tooltips.Insert(tooltips.Count - 1, clickerLine);
                    }
                }

                // How Fargo's DLC does it.
                if (item.type == ModContent.ItemType<UniverseSoul>() && !item.social)
                {
                    if (SoulsItem.IsNotRuminating(item))
                    {
                        const string ConjuristsSoul = "[i:FargowiltasSouls/ConjuristsSoul]";
                        int Conjurist = tooltips.FindIndex(t => t.Text.Contains(ConjuristsSoul));
                        tooltips[Conjurist].Text = tooltips[Conjurist].Text.Replace(ConjuristsSoul, ConjuristsSoul + "[i:ResonantSouls/ApiaristsSoul]");
                    }
                    else
                    {
                        TooltipLine clickerLine = new(Mod, "ClickerEffect", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.Bombus"));
                        tooltips.Insert(tooltips.Count - 1, clickerLine);
                    }
                }
            }
        }
    }
}
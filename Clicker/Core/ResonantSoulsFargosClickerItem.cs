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
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsFargosClickerConfig.Instance?.ClickerCompat ?? false;
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
            if (item.type == ModContent.ItemType<MicroverseSoul>() && !item.social)
            {
                if (SoulsItem.IsNotRuminating(item))
                {
                    int Forces = tooltips.FindIndex(line => line.Name == "Forces");
                    tooltips[Forces].Text = "[i:FargoClickers/ForceOfMatrix]" + tooltips[Forces].Text;
                }
                else
                {
                    TooltipLine clickerLine = new(Mod, "ClickerEffect", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.Clicker"));
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
                    tooltips[Conjurist].Text = tooltips[Conjurist].Text.Replace(ConjuristsSoul, ConjuristsSoul + "[i:FargoClickers/MasterPlayerSoul]");
                }
                else
                {
                    TooltipLine masterPlayer = new(Mod, "masterPlayer", Language.GetTextValue("Mods.ResonantSouls.Items.AddedEffects.ClickerUniverse"));
                    tooltips.Insert(tooltips.Count - 1, masterPlayer);
                }
            }
        }
    }
}
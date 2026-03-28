using System.Collections.Generic;
using System.Linq;
using ClickerClass;
using FargoClickers;
using FargoClickers.Content.Items.Accessories;
using FargowiltasSouls.Content.Items;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using ResonantSouls.Common.Utilities;
using ResonantSouls.Content.Items.Accessories.Souls;
using Terraria.Localization;

namespace ResonantSouls.Clicker.Core
{
    [JITWhenModsEnabled(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    [ExtendsFromMod(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    public class FargoClickersGlobalItem : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsFargosClickerConfig.ClickerCompat;
        Recipe? recipe;
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];

                if (recipe.HasResult<UniverseSoul>())
                    recipe.SafeAddToRecipe<MasterPlayerSoul>();
            }
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            ClickerPlayer mp = player.Clicker();
            int type = item.type;
            bool Microverse = type == ItemType<MicroverseSoul>() || type == ItemType<EternitySoul>();
            bool Universe = type == ItemType<UniverseSoul>() || type == ItemType<EternitySoul>();

            if (Microverse)
            {
                ForceOfMatrix.UpdateForceOfMatrix(player, item);
            }
            if (Universe)
            {
                mp.clickerRadius += 2f;
                mp.clickerBonusPercent += 0.2f;
                MasterPlayerSoul.UpdateMasterPlayerSoulAccessories(item, player, hideVisual);
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int Tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");
            const string key = "Mods.ResonantSouls.Items.";

            if (item.type == ItemType<UniverseSoul>())
            {
                if (SoulsItem.IsNotRuminating(item))
                {
                    if (!item.social)
                    {
                        const string conjurists = "[i:FargowiltasSouls/ConjuristsSoul]";
                        int extraeff = tooltips.FindIndex(t => t.Text.Contains(conjurists));
                        tooltips[extraeff].Text = tooltips[extraeff].Text.Replace(conjurists, conjurists + $"[i:{ModCompatibility.FargoClickers.Name}/MasterPlayerSoul]");
                    }
                }
                else
                {
                    var lines = tooltips[Tooltip0].Text.Split("\n").ToList();
                    lines.Insert(lines.Count - 1, Language.GetTextValue(key + "AddedEffects.ClickerUniverse"));
                    tooltips[Tooltip0].Text = string.Join("\n", lines);
                }
            }
        }
    }
}
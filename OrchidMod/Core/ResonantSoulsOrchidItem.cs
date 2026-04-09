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
using OrchidMod.Common;
using OrchidMod.Common.Global.Items;
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
            int type = item.type;
            bool Universe = type == ItemType<UniverseSoul>() || type == ItemType<EternitySoul>();
            OrchidGuardian mp = ResonantSoulsOrchidSystems.GuardianPlayer(player);

            if (Universe)
            {
                player.AddEffect<GuardianEffect>(item);
            }
            if (type == ItemType<StyxCrown>())
            {
                mp.GuardianGuardMax += 3;
                mp.GuardianSlamMax += 3;
            }
            else if (type == ItemType<EternalFlame>())
            {
                mp.GuardianGuardMax += 6;
                mp.GuardianSlamMax += 6;
            }
            else if (type == ItemType<NekomiHood>())
            {
                mp.GuardianGuardMax += 1;
            }
            else if (type == ItemType<NekomiHoodie>())
            {
                mp.GuardianSlamMax += 1;
            }
            else if (type == ItemType<GaiaHelmet>())
            {
                mp.GuardianGuardMax += 1;
                mp.GuardianSlamMax += 1;
            }
            else if (type == ItemType<GaiaPlate>())
            {
                mp.GuardianGuardMax += 1;
                mp.GuardianSlamMax += 1;
            }
            else if (type == ItemType<EridanusLegwear>())
            {
                mp.GuardianGuardMax += 2;
                mp.GuardianSlamMax += 2;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int LastTooltip = tooltips.FindLastIndex(t => t.Name.StartsWith("Tooltip") && t.Mod == "Terraria");
            int Tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");
            const string key = "Mods.ResonantSouls.Items.";
            int type = item.type;
            List<string>? lines;
            if (type == ItemType<UniverseSoul>())
            {
                if (SoulsItem.IsNotRuminating(item))
                {
                    if (!item.social)
                    {
                        const string conjurists = "[i:FargowiltasSouls/ConjuristsSoul]";
                        int extraeff = tooltips.FindIndex(t => t.Text.Contains(conjurists));
                        tooltips[extraeff].Text = tooltips[extraeff].Text.Replace(conjurists, conjurists + "[i:ResonantSouls/GuardiansSoul]");
                    }
                }
                else
                {
                    lines = tooltips[Tooltip0].Text.Split("\n").ToList();
                    lines.Insert(lines.Count - 1, Language.GetTextValue(key + "AddedEffects.GuardianUniverse"));
                    tooltips[Tooltip0].Text = string.Join("\n", lines);
                }
            }
            else if (type == ItemType<EternalFlame>())
            {
                lines = tooltips[LastTooltip].Text.Split("\n").ToList();
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 6));
                tooltips[LastTooltip].Text = string.Join("\n", lines);
            }
            else if (type == ItemType<StyxCrown>())
            {
                lines = tooltips[LastTooltip].Text.Split("\n").ToList();
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 3));
                tooltips[LastTooltip].Text = string.Join("\n", lines);
            }
            else if (type == ItemType<NekomiHood>())
            {
                lines = tooltips[LastTooltip].Text.Split("\n").ToList();
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuards", 1));
                tooltips[LastTooltip].Text = string.Join("\n", lines);
            }
            else if (type == ItemType<NekomiHoodie>())
            {
                lines = tooltips[LastTooltip].Text.Split("\n").ToList();
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseSlams", 1));
                tooltips[LastTooltip].Text = string.Join("\n", lines);
            }
            else if (type == ItemType<GaiaHelmet>())
            {
                lines = tooltips[LastTooltip].Text.Split("\n").ToList();
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 3));
                tooltips[LastTooltip].Text = string.Join("\n", lines);
            }
            else if (type == ItemType<GaiaPlate>())
            {
                lines = tooltips[LastTooltip].Text.Split("\n").ToList();
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 3));
                tooltips[LastTooltip].Text = string.Join("\n", lines);
            }
            else if (type == ItemType<EridanusLegwear>())
            {
                lines = tooltips[LastTooltip].Text.Split("\n").ToList();
                lines.Insert(lines.Count, Language.GetTextValue(key + "IncreaseGuardsAndSlams", 2));
                tooltips[LastTooltip].Text = string.Join("\n", lines);
            }
            else if (type == ItemType<GuardiansSoul>())
            {
                if (GetInstance<OrchidClientConfig>().ShowClassTags)
                {
                    AddClassTagToTooltips(item, tooltips);
                }
            }
        }
        private static void AddClassTagToTooltips(Item item, List<TooltipLine> tooltips) => typeof(OrchidGlobalItem).GetMethod("AddClassTagToTooltips", LumUtils.UniversalBindingFlags)?.Invoke(null, [ item, tooltips]);
    }
}
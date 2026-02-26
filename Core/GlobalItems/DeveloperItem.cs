using ResonantSouls.Content.Items.Accessories.Developer.AstraMark;
using Terraria.Localization;

namespace ResonantSouls.Core.GlobalItems
{
    public class ResonantDeveloper : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => devItems.ContainsKey(entity.type) && entity.active;
        public override bool InstancePerEntity => true;
        public Dictionary<int, string> devItems = new()
        {
            [ModContent.ItemType<AstraMark>()] = "Ropro0923",
        };
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine Developer = new(Mod, "Dedicated", "- " + Language.GetTextValue("Mods.ResonantSouls.Items.Developer.Dedicated") + " " + Language.GetTextValue($"Mods.ResonantSouls.Items.Developer.{devItems[item.type]}") + " -")
            {
                OverrideColor = Color.Lerp(new(34, 221, 151), new(57, 170, 178), (float)Math.Abs(Math.Sin(Main.GlobalTimeWrappedHourly)))
            };
            tooltips.Add(Developer);
        }
    }
}
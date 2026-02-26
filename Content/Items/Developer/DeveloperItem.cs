using Terraria.Localization;

namespace ResonantSouls.Content.Items.Developer
{
    public abstract class DeveloperItem : ModItem
    {
        public abstract string Developer { get; }
        public sealed override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            SafeModifyTooltips(tooltips);

            Color color1 = new(34, 221, 151);
            Color color2 = new(57, 170, 178);

            Color color = Color.Lerp(color1, color2, (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 2.0) * 0.5 + 0.5));


            TooltipLine ded = new(Mod, "Dedicated", Language.GetTextValue("Mods.ResonantSouls.Items.Developer.Dedicated"))
            {
                OverrideColor = color
            };
            tooltips.Add(ded);

            TooltipLine dev = new(Mod, "Developer", Language.GetTextValue($"Mods.ResonantSouls.Items.Developer.{Developer}"))
            {
                OverrideColor = color
            };
            tooltips.Add(dev);
        }
        public virtual void SafeModifyTooltips(List<TooltipLine> tooltips) { }
        public virtual void SafeAddRecipes() { }
    }
}
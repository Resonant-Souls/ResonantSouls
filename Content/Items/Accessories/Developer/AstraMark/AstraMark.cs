namespace ResonantSouls.Content.Items.Accessories.Developer.AstraMark
{
    public class AstraMark : SoulsItem
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSouls.astraMark;
        public override void SetDefaults()
        {
            Item.accessory = true;
        }
    }
}
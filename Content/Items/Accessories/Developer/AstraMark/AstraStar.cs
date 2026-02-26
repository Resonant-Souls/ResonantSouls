namespace ResonantSouls.Content.Items.Accessories.Developer.AstraMark
{
    public class AstraStar : ModProjectile
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSouls.astraMark;
        public override string Texture => FargoSoulsUtil.EmptyTexture;
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.hostile = false;
        }
    }
}
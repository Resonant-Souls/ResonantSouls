using Luminance.Core.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace ResonantSouls
{
    public class Proj : ModProjectile
    {
        public override string Texture => FargoSoulsUtil.EmptyTexture;
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;

            ManagedShader AbomRitualBackgroundShader = ShaderManager.GetShader("ResonantSouls.AbomRitualBackgroundShader");
            AbomRitualBackgroundShader.TrySetParameter("globalTime", Main.GlobalTimeWrappedHourly);
            AbomRitualBackgroundShader.TrySetParameter("glowStrength", 0.6);
            AbomRitualBackgroundShader.TrySetParameter("glowSpeed", 4f);
            AbomRitualBackgroundShader.TrySetParameter("glowColor", new Vector4(0.3f, 0.8f, 1f, 1f));

            spriteBatch.End();

            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                Main.DefaultSamplerState,
                DepthStencilState.None,
                Main.Rasterizer,
                AbomRitualBackgroundShader.WrappedEffect,
                Main.GameViewMatrix.TransformationMatrix
            );
            return false;
        }

    }
}
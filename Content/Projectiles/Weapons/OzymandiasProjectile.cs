using System;
using System.Collections.Generic;
using FargowiltasSouls;
using FargowiltasSouls.Content.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace ResonantSouls.Content.Projectiles.Weapons
{
    public class OzymandiasProjectile : ModProjectile
    {
        public override string Texture => $"{Mod.Name}/Assets/Textures/Content/Projectiles/Weapons/{Name}";
        public Player Player => Main.player[Projectile.owner];
        FargoSoulsGlobalProjectile FargoProjectile => Projectile.FargoSouls();
        public override void SetDefaults()
        {
            Projectile.width = 110 + 110/2;
            Projectile.height = 114 + 114/2;
            //    Projectile.scale = 2;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            FargoProjectile.CanSplit = false;
            FargoProjectile.TimeFreezeImmune = true;
        //    Projectile.timeLeft = 2;
            Projectile.hide = true;
            //    Projectile.hide = true;
            //    Projectile.aiStyle = -1;    
        }
        public override void AI()
        {
            if (Projectile.owner < 0 || Projectile.owner >= byte.MaxValue || !Player.active || Player.dead || !Player.channel)
            {
                Projectile.Kill();
                    return;
            }

            Projectile.rotation += Player.direction == 1 ? 0.25f : -0.25f;
            Projectile.Center = Player.RotatedRelativePoint(Player.MountedCenter);
            //    Projectile.Center = Player.RotatedRelativePoint(Player.MountedCenter);
            //    Projectile.direction = -Player.direction;
        }
    }
    public class OzymandiasDrawLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new Between(PlayerDrawLayers.Torso, PlayerDrawLayers.ArmOverItem);
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;

            if (player.ownedProjectileCounts[ProjectileType<OzymandiasProjectile>()] <= 0)
                return;

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile proj = Main.projectile[i];

                if (!proj.active || proj.owner != player.whoAmI || proj.type != ProjectileType<OzymandiasProjectile>())
                    continue;

                Texture2D tex = TextureAssets.Projectile[proj.type].Value;

                //    Vector2 pos = proj.Center - Main.screenPosition;
                Vector2 pos = player.Center - Main.screenPosition;
                SpriteEffects effects = player.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

                drawInfo.DrawDataCache.Add(new(
                    tex,
                    pos,
                    null,
                    Color.White,
                    proj.rotation,
                    tex.Size() / 2,
                    proj.scale * 1.5f,
                    effects,
                    0
                ));

                break;
            }
        }
    }
}
using Microsoft.Xna.Framework;
using ResonantSouls.Content.Projectiles.Weapons;
using ResonantSouls.Core.Abstracts.Items;
using Terraria.DataStructures;
using Terraria.ID;

namespace ResonantSouls.Content.Items.Weapons.Melee
{
    public class Ozymandias : ResonantDeveloperItem
    {
        public override bool IsLoadingEnabled(Mod mod) => false; // Wait until mod is more developed to enable
        public override string Developer => "Ropro0923";
        public override string ItemPath => "Weapons/Melee";
        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.width = 76;
            Item.height = 80;
            Item.useTime = Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.channel = true;
            //    Item.knockBack = 5f;
            //    Item.value = Item.sellPrice(gold: 10);
            Item.DamageType = DamageClass.Melee;
            //    Item.rare = RarityType<InfernumProfanedRarity>();
            Item.autoReuse = true;
            Item.shoot = ProjectileType<OzymandiasProjectile>();
            Item.noMelee = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player == Main.LocalPlayer && player.ownedProjectileCounts[Item.shoot] < 1)
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}
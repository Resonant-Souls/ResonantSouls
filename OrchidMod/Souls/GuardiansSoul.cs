using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using OrchidMod;
using OrchidMod.Common;
using OrchidMod.Common.Attributes;
using OrchidMod.Content.Guardian;
using OrchidMod.Content.Guardian.Accessories;
using OrchidMod.Content.Guardian.Weapons.Gauntlets;
using OrchidMod.Content.Guardian.Weapons.Quarterstaves;
using OrchidMod.Content.Guardian.Weapons.Shields;
using OrchidMod.Content.Guardian.Weapons.Standards;
using OrchidMod.Content.Guardian.Weapons.Warhammers;
using ResonantSouls.Common.Utilities;
using Terraria.DataStructures;
using ResonantSouls.OrchidMod.Core;
using Terraria.ID;

namespace ResonantSouls.OrchidMod.Souls
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    [ClassTag(ClassTags.Guardian)]
    public class GuardiansSoul : BaseSoul
    {
        public override string Texture => this.OrchidTexture();
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 12));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = Item.height = 50;
            //      Item.height = 24;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            OrchidGuardian modPlayer = ResonantSoulsOrchidSystems.GuardianPlayer(player);

            player.AddEffect<GuardianEffect>(Item);
            player.GetDamage<GuardianDamageClass>() += 0.26f;
            player.GetCritChance<GuardianDamageClass>() += 0.13f;
            player.GetAttackSpeed<MeleeDamageClass>() += 0.12f;

            ModContent.GetInstance<SturdySlab>().UpdateAccessory(player, hideVisual);
            ModContent.GetInstance<TempleSpike>().UpdateAccessory(player, hideVisual);
            modPlayer.GuardianSpikeTemple = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TempleSpike>())
                .AddRecipeGroup("ResonantSouls:AnySturdySlab")
                .AddIngredient(ModContent.ItemType<FlamingQuarterstaff>())
                .AddIngredient(ModContent.ItemType<JungleWarhammer>())
                .AddIngredient(ModContent.ItemType<BeeGauntlet>())
                .AddIngredient(ModContent.ItemType<NightShield>())
                .AddIngredient(ModContent.ItemType<ShardQuarterstaff>())
                .AddIngredient(ModContent.ItemType<JungleWarhammer>())
                .AddIngredient(ModContent.ItemType<SpectreShield>()) // Replace with with biome weapon when added
                .AddIngredient(ModContent.ItemType<PlanteraStandard>()) // Replace with duke gauntlet when added
                .AddIngredient(ModContent.ItemType<JungleWarhammer>())
                .AddTile<LuminiteOmniforgeTile>()
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TempleSpike>())
                .AddRecipeGroup("ResonantSouls:AnySturdySlab")
                .AddIngredient(ModContent.ItemType<HeavyChain>())
                .AddIngredient(ModContent.ItemType<SpectreShield>()) // Replace with with biome weapon when added
                .AddIngredient(ModContent.ItemType<PlanteraStandard>()) // Replace with duke gauntlet when added
                .AddIngredient(ModContent.ItemType<AbomEnergy>(), 10)
                .AddTile<LuminiteOmniforgeTile>()
                .Register();
        }
    }
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    [ClassTag(ClassTags.Guardian)]
    public class GuardianEffect : AccessoryEffect
    {
        public override Header? ToggleHeader => null;
        public override int ToggleItemType => ModContent.ItemType<GuardiansSoul>();
        public override void PostUpdate(Player player)
        {
            OrchidGuardian mp = ResonantSoulsOrchidSystems.GuardianPlayer(player);
            mp.GuardianGuardRecharge *= 1.75f;
            mp.GuardianSlamRecharge *= 3.4f;
            mp.GuardianRegenThreshold *= 1.25f;
            mp.GuardianBonusRune = (int)(mp.GuardianBonusRune * 1.2f);
            mp.ParryInvincibilityBonus += 5;
            mp.GuardianRuneTimer *= 1.2f;
            mp.GuardianStandardTimer *= 1.2f;
            mp.GuardianStandardRange *= 1.2f;
            mp.GuardianSlamDistance *= 1.5f;
            mp.GuardianBlockDuration *= 1.25f;
            mp.GuardianParryDuration *= 1.25f;
            mp.GuardianMeleeSpeed *= 1.25f;
            mp.GuardianWeaponScale *= 1.5f;
            mp.GuardianGuardMax += 2;
            mp.GuardianSlamMax += 3;

            if (player.FargoSouls().Eternity)
            {
                mp.GuardianGuardRecharge *= 1.2f;
                mp.GuardianSlamRecharge *= 2f;
                mp.GuardianRegenThreshold *= 1.25f;
                mp.GuardianBonusRune = (int)(mp.GuardianBonusRune * 1.3f);
                mp.ParryInvincibilityBonus += 8;
                mp.GuardianRuneTimer *= 1.3f;
                mp.GuardianStandardTimer *= 1.2f;
                mp.GuardianStandardRange *= 1.2f;
                mp.GuardianSlamDistance *= 1.25f;
                mp.GuardianBlockDuration *= 1.25f;
                mp.GuardianParryDuration *= 1.15f;
                mp.GuardianMeleeSpeed *= 1.05f;
                mp.GuardianWeaponScale *= 1.2f;
                mp.GuardianGuard = mp.GuardianGuardMax;
                mp.GuardianSlam = mp.GuardianSlamMax;
            }
        }
    }
}
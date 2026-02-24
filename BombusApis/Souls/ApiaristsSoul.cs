using BombusApisBee.BeeDamageClass;
using BombusApisBee.Items.Accessories.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Core.ModPlayers;
using ResonantSouls.BombusApis.Core;
using Terraria.DataStructures;

namespace ResonantSouls.BombusApis.Souls
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ApiaristsSoul : BaseSoul
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
        public override string Texture => "ResonantSouls/BombusApis/Assets/Sprites/ApiaristsSoul";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Item.width = Item.height = 64;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<ApiaristSoulThing>(Item);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<HymenoptrianNecklace>())
            .AddIngredient(ModContent.ItemType<HoneyManipulator>())
            .AddIngredient(ModContent.ItemType<BeeEmblem>())
            .AddIngredient(ModContent.ItemType<Skelecomb>())
            .AddIngredient(ModContent.ItemType<TheTraitorsSaxophone>())
            .AddIngredient(ModContent.ItemType<Ambrosia>())
            .AddIngredient(ModContent.ItemType<SpectralBeeTome>())
            .AddIngredient(ModContent.ItemType<PumpkinetScepter>())
            .AddIngredient(ModContent.ItemType<HoneyFlareCannon>())
            .AddIngredient(ModContent.ItemType<HymenoptraFlasks>())
            .AddTile<LuminiteOmniforgeTile>()
            .Register();


            // Alt with no weapons
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<HymenoptrianNecklace>())
            .AddIngredient(ModContent.ItemType<HoneyManipulator>())
            .AddIngredient(ModContent.ItemType<BeeEmblem>())
            .AddIngredient(ModContent.ItemType<AbomEnergy>(), 10)
            .AddTile<LuminiteOmniforgeTile>()
            .Register();
        }
    }
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ApiaristSoulThing : AccessoryEffect
    {
        private static ModItem necklace;
        private static ModItem manipulator;
        public override void SetStaticDefaults()
        {
            ModCompatibility.BombusApisBee.Mod.TryFind("HymenoptrianNecklace", out ModItem n);
            ModCompatibility.BombusApisBee.Mod.TryFind("HoneyManipulator", out ModItem m);
            necklace = n;
            manipulator = m;
        }
        public override Header ToggleHeader => null;
        public override int ToggleItemType => ModContent.ItemType<ApiaristsSoul>();
        public override void PostUpdate(Player player)
        {
            FargoSoulsPlayer modPlayer = player.FargoSouls();
            BeeDamagePlayer beePlayer = player.GetModPlayer<BeeDamagePlayer>();

            player.GetDamage<HymenoptraDamageClass>() += 0.25f;
            player.GetCritChance<HymenoptraDamageClass>() += 0.10f;
            player.GetAttackSpeed<HymenoptraDamageClass>() += 0.15f;

            beePlayer.BeeResourceMax2 += modPlayer.Eternity ? 999 : 200;
            // TODO: Make it regen a lot faster
            //    beePlayer.BeeResourceRegenTimer += modPlayer.Eternity ? 30 : 15;

            necklace?.UpdateAccessory(player, true);
            manipulator?.UpdateAccessory(player, true);
        }
    }
}


using BombusApisBee;
using BombusApisBee.BeeDamageClass;
using BombusApisBee.Items.Accessories.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using ResonantSouls.Common.Utilities;
using Terraria.DataStructures;
using Terraria.ID;

namespace ResonantSouls.BombusApis.Souls
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ApiaristsSoul : BaseSoul
    {
        public override string Texture => this.BombusTexture();
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Item.width = Item.height = 64;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<ApiaristEffect>(Item);
            player.GetDamage<HymenoptraDamageClass>() += 1.25f;
            player.GetCritChance<HymenoptraDamageClass>() += 0.10f;
            player.GetAttackSpeed<HymenoptraDamageClass>() += 0.15f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemType<HymenoptrianNecklace>())
            .AddIngredient(ItemType<HoneyManipulator>())
            .AddIngredient(ItemType<BeeEmblem>())
            .AddIngredient(ItemType<Skelecomb>())
            .AddIngredient(ItemType<TheTraitorsSaxophone>())
            .AddIngredient(ItemType<Ambrosia>())
            .AddIngredient(ItemType<SpectralBeeTome>())
            .AddIngredient(ItemType<PumpkinetScepter>())
            .AddIngredient(ItemType<HoneyFlareCannon>())
            .AddIngredient(ItemType<HymenoptraFlasks>())
            .AddTile<LuminiteOmniforgeTile>()
            .Register();


            // Alt with no weapons
            CreateRecipe()
            .AddIngredient(ItemType<HymenoptrianNecklace>())
            .AddIngredient(ItemType<HoneyManipulator>())
            .AddIngredient(ItemType<BeeEmblem>())
            .AddIngredient(ItemType<AbomEnergy>(), 10)
            .AddTile<LuminiteOmniforgeTile>()
            .Register();
        }
    }
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ApiaristEffect : AccessoryEffect
    {
        readonly static Mod ba = ModCompatibility.BombusApisBee.Mod;
        private static ModItem? necklace = ba.Find<ModItem>("HymenoptrianNecklace");
        private static ModItem? manipulator = ba.Find<ModItem>("HoneyManipulator");
        public override Header? ToggleHeader => null;
        public override int ToggleItemType => ItemType<ApiaristsSoul>();
        public override void PostUpdate(Player player)
        {
            necklace?.UpdateAccessory(player, true);
            manipulator?.UpdateAccessory(player, true);
        }
    }
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ApiaristSoulPlayer : ModPlayer
    {
        public override void UpdateEquips()
        {
            FargoSoulsPlayer mp = Player.FargoSouls();
            BeeDamagePlayer bp = Player.Hymenoptra();

            if (Player.HasEffect<ApiaristEffect>())
            {
                bp.BeeResourceMax2 += mp.Eternity ? 999 : 200;

                if (mp.Eternity)
                {
                    bp.BeeResourceCurrent = bp.BeeResourceMax2;
                }
                else
                {
                    bp.BeeResourceIncrease *= 3;
                }
            }
        }
    }
}
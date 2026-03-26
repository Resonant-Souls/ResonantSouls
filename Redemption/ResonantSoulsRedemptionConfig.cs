using Terraria.ModLoader.Config;

namespace ResonantSouls.Redemption
{
    [JITWhenModsEnabled(ModCompatibility.Redemption.Name)]
    [ExtendsFromMod(ModCompatibility.Redemption.Name)]
    public class ResonantSoulsRedemptionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static ResonantSoulsRedemptionConfig? Instance;
        public override void OnChanged() => Instance = this;
        public override void OnLoaded() => Instance = this;
    }
}
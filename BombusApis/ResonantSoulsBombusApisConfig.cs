using Terraria.ModLoader.Config;

namespace ResonantSouls.BombusApis
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static ResonantSoulsBombusApisConfig? Instance;
        public override void OnChanged() => Instance = this;
        public override void OnLoaded() => Instance = this;
    }
}
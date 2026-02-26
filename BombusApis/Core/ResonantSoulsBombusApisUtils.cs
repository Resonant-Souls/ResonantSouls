namespace ResonantSouls.BombusApis.Core
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    internal static class ResonantSoulsBombusApisUtils
    {
        internal static string BombusTexture(this ModType type)
        {
            return $"ResonantSouls/BombusApis/Assets/Sprites/{type.Name}";
        }
    }
}
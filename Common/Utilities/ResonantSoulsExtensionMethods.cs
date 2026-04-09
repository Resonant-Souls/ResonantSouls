namespace ResonantSouls.Common.Utilities
{
    public static class ResonantSoulsExtensionMethods
    {
        internal static string BombusTexture(this ModType type) => $"ResonantSouls/BombusApis/Assets/Sprites/{type.Name}";
        internal static string OrchidTexture(this ModType type) => $"ResonantSouls/OrchidMod/Assets/Sprites/{type.Name}";
    }
}
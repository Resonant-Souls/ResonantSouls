using System.Collections.Generic;

namespace ResonantSouls.Core
{
    public static class ModCompatibility
    {
        public static List<bool> LoadedMicroverseMods =
        [
            BombusApisBee.Loaded,
            FargoClickers.Loaded,
        ];
        public static List<bool> LoadedChampionMods =
        [
            BombusApisBee.Loaded,
            FargoClickers.Loaded,
        ];
        public static bool AnyMicroverse => LoadedMicroverseMods.Contains(true);
        public static bool AnyChampion => LoadedChampionMods.Contains(true);
        public static class Fargowiltas
        {
            public const string Name = "Fargowiltas";
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class FargowiltasCrossmod
        {
            public const string Name = "FargowiltasCrossmod";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class CalamityMod
        {
            public const string Name = "CalamityMod";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }

        public static class FargowiltasSouls
        {
            public const string Name = "FargowiltasSouls";
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class Luminance
        {
            public const string Name = "Luminance";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class Daybreak
        {
            public const string Name = "Daybreak";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class BombusApisBee
        {
            public const string Name = "BombusApisBee";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class ClickerClass
        {
            public const string Name = "ClickerClass";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class FargoClickers
        {
            public const string Name = "FargoClickers";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class OrchidMod
        {
            public const string Name = "OrchidMod";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
    }
}
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ResonantSouls.Clicker
{
    [JITWhenModsEnabled(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    [ExtendsFromMod(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    public class ResonantSoulsFargosClickerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static ResonantSoulsFargosClickerConfig? Instance;
        public override void OnChanged() => Instance = this;
        public override void OnLoaded() => Instance = this;

        [Header("LoadedContent")]

        [ReloadRequired]
        [DefaultValue(true)]
        public bool Compat { get; set; }
        public static bool ClickerCompat => Instance?.Compat ?? false;
    }
}
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ResonantSouls.BombusApis.Core
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static ResonantSoulsBombusApisConfig Instance;
        public override void OnChanged() => Instance = this;
        public override void OnLoaded() => Instance = this;

        [Header("LoadedContent")]

        [ReloadRequired]
        [DefaultValue(true)]
        public bool Enchantments { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool EternityModeAccessories { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool Energizers { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool QualityOfLife { get; set; }
    }
}
using System.ComponentModel;
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

        [Header("LoadedContent")]

        [ReloadRequired]
        [DefaultValue(true)]
        public bool Enchants { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool EModeAcc { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool Energizer { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool QoL { get; set; }


        public static bool Enchantments => Instance?.Enchants ?? false;
        public static bool EternityModeAccessories => Instance?.EModeAcc ?? false;
        public static bool Energizers => Instance?.Energizer ?? false;
        public static bool QualityOfLife => Instance?.QoL ?? false;
    }
}
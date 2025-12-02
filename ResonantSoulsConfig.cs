using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ResonantSouls
{
    public class ResonantSoulsClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        internal static ResonantSoulsClientConfig Instance;
        public override void OnChanged() => Instance = this;
        public override void OnLoaded() => Instance = this;
        [Header("Miscellaneous")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool WarningNotification { get; set; }
    }
}
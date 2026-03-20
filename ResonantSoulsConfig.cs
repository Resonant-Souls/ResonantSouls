using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ResonantSouls
{
    public class ResonantSoulsClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static ResonantSoulsClientConfig? Instance;
        public override void OnChanged() => Instance = this;
        public override void OnLoaded() => Instance = this;

        [Header("Miscellaneous")]

        [DefaultValue(true)]
        public bool WarnNotif { get; set; }

        public static bool WarningNotification => Instance?.WarnNotif ?? false;
    }
}
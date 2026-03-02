global using Terraria;
global using Terraria.ModLoader;
global using ResonantSouls.Core;

namespace ResonantSouls
{
    public class ResonantSouls : Mod
    {
        public const bool astraMark = false;
        internal static ResonantSouls? Instance;
        public override void Load()
        {
            Instance = this;
            Fargowiltas.Fargowiltas.SoulsMods.Add(Instance.Name);
        }
        public override void Unload()
        {
            Instance = null;
        }
    }
}
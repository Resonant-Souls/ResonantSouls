using Fargowiltas.Common.Systems.Collections;

namespace ResonantSouls.Common.Utilities
{
    public class ResonantSoulsUtilities
    {
        internal static void SetSacrifice(params int[] types)
        {
            for (int i = 0; i < types.Length - 1; i += 2)
            {
                int type = types[i];
                int count = types[i + 1];

                FargoItemSets.SacrificeCountDefault[type] = count;
            }
        }
        internal static void SetHardmodeSacrifice(params int[] types)
        {
            for (int i = 0; i < types.Length - 1; i += 2)
            {
                int type = types[i];
                int count = types[i + 1];

                FargoItemSets.SacrificeCountDefault[type] = count;
                FargoItemSets.HardmodeSacrifice[type] = true;
            }
        }
    }
}
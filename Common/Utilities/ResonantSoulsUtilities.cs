using System.Collections.Generic;
using System.Reflection;
using Fargowiltas.Common.Systems.Collections;
using Fargowiltas.Content.Items.CaughtNPCs;

namespace ResonantSouls.Common.Utilities
{
    public class ResonantSoulsUtilities
    {
        public static void Add(string internalName, int id)
        {
            ResonantSouls.Instance ??= ModContent.GetInstance<ResonantSouls>();
            CaughtNPCItem item = new(internalName, id);
            ResonantSouls.Instance.AddContent(item);
            FieldInfo? info = typeof(CaughtNPCItem).GetField("CaughtTownies", LumUtils.UniversalBindingFlags);
            Dictionary<int, int>? list = (Dictionary<int, int>?)info?.GetValue(info);
            list?.Add(id, item.Type);
            info?.SetValue(info, list);
        }
        internal static void SetSacrifice(int count = 1, params int[] types)
        {
            foreach (int type in types)
            {
                FargoItemSets.SacrificeCountDefault[type] = count;
            }
        }
        internal static void SetHardmodeSacrifice(int count = 1, params int[] types)
        {
            foreach (int type in types)
            {
                FargoItemSets.SacrificeCountDefault[type] = count;
                FargoItemSets.HardmodeSacrifice[type] = true;
            }
        }

    }
}
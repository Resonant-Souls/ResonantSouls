using System.Reflection;
using Fargowiltas.Content.Items.CaughtNPCs;
using Luminance.Common.Utilities;
using ResonantSouls.Core.GlobalItems;

namespace ResonantSouls.Core
{
    public static class ResonantSoulsUtilities
    {
        public static void Add(string internalName, int id)
        {
            ResonantSouls.Instance ??= ModContent.GetInstance<ResonantSouls>();
            CaughtNPCItem item = new(internalName, id);
            ResonantSouls.Instance.AddContent(item);
            FieldInfo info = typeof(CaughtNPCItem).GetField("CaughtTownies", Utilities.UniversalBindingFlags);
            Dictionary<int, int> list = (Dictionary<int, int>)info.GetValue(info);
            list.Add(id, item.Type);
            info.SetValue(info, list);
        }
        public static ResonantDeveloper ResonantDeveloper(this Item item) => item.GetGlobalItem<ResonantDeveloper>();
    }
}
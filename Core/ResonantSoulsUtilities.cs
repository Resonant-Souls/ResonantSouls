using System.Reflection;
using Fargowiltas.Content.Items.CaughtNPCs;
using Luminance.Common.Utilities;

namespace ResonantSouls.Core
{
    public class ResonantSoulsUtilities
    {
        public static void Add(string internalName, int id)
        {
            if (ResonantSouls.Instance == null)
            {
                ResonantSouls.Instance = ModContent.GetInstance<ResonantSouls>();
            }
            CaughtNPCItem item = new(internalName, id);
            ResonantSouls.Instance.AddContent(item);
            FieldInfo info = typeof(CaughtNPCItem).GetField("CaughtTownies", Utilities.UniversalBindingFlags);
            Dictionary<int, int> list = (Dictionary<int, int>)info.GetValue(info);
            list.Add(id, item.Type);
            info.SetValue(info, list);
        }
    }
}
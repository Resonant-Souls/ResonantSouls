using ResonantSouls.Core.Globals.Items;

namespace ResonantSouls.Common.Utilities
{
    public static class ResonantSoulsExtensionMethods
    {
        public static ResonantDeveloper ResonantDeveloper(this Item item) => item.GetGlobalItem<ResonantDeveloper>();
    }
}
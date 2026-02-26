namespace ResonantSouls.Clicker.Core
{
    [JITWhenModsEnabled(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    [ExtendsFromMod(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    public class ResonantSoulsFargosClickerCompat : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsFargosClickerConfig.Instance.ClickerCompat;
        public override void PostSetupContent()
        {
            ModCompatibility.FargoClickers.Mod.Call("CSESupport");
        }
    }
}
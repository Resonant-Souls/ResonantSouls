using BombusApisbee.NPCs;

namespace ResonantSouls.BombusApis.Core
{

    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisCaughtNPCs : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.QualityOfLife;
        public override void Load()
        {
            ResonantSoulsUtilities.Add("TraitorBee", ModContent.NPCType<TheTraitorBee>());
        }
    }
}
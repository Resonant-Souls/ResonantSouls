using System.Linq;
using FargowiltasSouls.Content.Items.Summons;
using FargowiltasSouls.Core.Globals;

namespace ResonantSouls.Core.Globals.Items
{
    public class SigilOfChampionsFix : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod) => ModCompatibility.AnyChampion;
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.ModItem is SigilOfChampions;
        public override bool CanUseItem(Item item, Player player)
        {
            //    return Main.npc.Any(npc => npc.whoAmI == EModeGlobalNPC.championBoss && npc.active && npc is not null);

            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.whoAmI == EModeGlobalNPC.championBoss)
                    return false;
            }
            return true;
        }
    }
}
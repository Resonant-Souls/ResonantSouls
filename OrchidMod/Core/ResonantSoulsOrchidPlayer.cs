using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using OrchidMod.Content.Guardian;

namespace ResonantSouls.OrchidMod.Core
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            FargoSoulsPlayer mp = Player.FargoSouls();
            DamageClass damage = Player.HeldItem.DamageType;
            if (mp.Atrophied)
            {
                Player.GetAttackSpeed<GuardianDamageClass>() /= 1.5f;
                if (damage.CountsAsClass<GuardianDamageClass>() || damage.CountsAsClass<GuardianDamageClass>())
                    mp.AttackSpeed /= 1.5f;

                Player.GetDamage<GuardianDamageClass>() /= 1.5f;
            }
        }
    }
}
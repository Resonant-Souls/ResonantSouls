using FargowiltasSouls;
using OrchidMod.Content.Guardian;

namespace ResonantSouls.OrchidMod.Core
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            if (Player.FargoSouls().Atrophied)
            {
                Player.GetAttackSpeed<GuardianDamageClass>() /= 1.5f;
                if (Player.HeldItem.DamageType.CountsAsClass<GuardianDamageClass>() || Player.HeldItem.DamageType.CountsAsClass<GuardianDamageClass>())
                    Player.FargoSouls().AttackSpeed /= 1.5f;

                Player.GetDamage<GuardianDamageClass>() /= 1.5f;
            }
        }
    }
}
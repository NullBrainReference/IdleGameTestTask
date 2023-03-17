using UnityEngine;

public class BloodlustEffect : SpellEffect, IModifire
{
    public BloodlustEffect()
    {
        HealthMod = 1;
        DamageMod = 0;
        TeamMod = UnitTeam.Ally;
    }

    public float HealthMod { get; set; }
    public float DamageMod { get; set; }
    public UnitTeam TeamMod { get; set; }

    public override void OnUse(UnitBase user, UnitBase enemy)
    {
        DamageMod = enemy.MaxHealth * 0.05f;
        user.Health += enemy.MaxHealth * 0.05f;
        //Debug.Log("Bloodlust used on " + enemy.UnitType+ " " + (enemy.Health).ToString());
    }
}

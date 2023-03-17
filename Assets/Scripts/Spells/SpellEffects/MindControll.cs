using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControll : SpellEffect, IDuration, IModifire
{
    public MindControll()
    {
        Duration = 5;
        TimeLeft = Duration;
        DurationType = DurationType.Duration;
        TeamMod = UnitTeam.Ally;
    }

    public float Duration { get; set; }
    public float TimeLeft { get; set; }
    public float HealthMod { get; set; }
    public float DamageMod { get; set; }
    public UnitTeam TeamMod { get; set; }

    public override void OnUpdate()
    {
        TimeLeft -= Time.deltaTime;
    }

    public override void EffectReset()
    {
        TimeLeft = Duration;
    }

    //public override void OnUse(UnitBase user, UnitBase enemy)
    //{
    //    if (enemy.UnitType == UnitType.Hero) return;
    //    
    //    enemy.unitController.ForceToCangeTarget(user.unitController);
    //}
}

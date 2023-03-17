using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitZombieBoss : UnitBase
{
    public UnitZombieBoss() : base()
    {
        this.maxHealth = 100;
        this.health = this.maxHealth;
        this.damageBase = 2;
        this.damage = this.damageBase;
        this.attackSpeed = 1;
        this.movementSpeed = 0.25f;
        this.team = UnitTeam.Enemy;
        this.unitType = UnitType.ZombieBoss;
    }
}

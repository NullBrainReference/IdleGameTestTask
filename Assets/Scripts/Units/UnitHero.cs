using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHero : UnitBase
{
	public UnitHero() : base()
	{
        this.maxHealth = 300;
        this.health = this.maxHealth;
        this.damageBase = 3;
        this.damage = this.damageBase;
        this.attackSpeed = 0.5f;
        this.team = UnitTeam.Ally;
        this.unitType = UnitType.Hero;
    }
}

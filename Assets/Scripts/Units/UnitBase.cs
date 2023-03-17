using System;
using System.Collections.Generic;
using UnityEngine;

public enum UnitTeam { Ally, Enemy }
public enum UnitType { Hero, Zombie, ZombieBoss };

public abstract class UnitBase
{
    protected float health;
    protected float maxHealth;
    protected float damage;
    protected float damageBase;
    protected float attackSpeed;
    protected float movementSpeed;
    
    protected UnitTeam team;
    protected UnitType unitType;

    protected List<SpellEffect> spellEffects;

    [NonSerialized] public UnitController unitController; 

    public float Health { 
        get { return health; } 
        set {
            health = value;
            if (health < 0 )
                health = 0;
            else if (health > maxHealth)
                health = maxHealth;
        } 
    }
    public float MaxHealth { get { return maxHealth; } }
    public float Damage { 
        get {
            float modifiedDamage = damageBase;

            foreach (SpellEffect effect in spellEffects) 
            { 
                if(effect.SpellEffectType == EffectType.Modifire)
                {
                    var modifire = effect as IModifire;

                    modifiedDamage += modifire.DamageMod;
                }
            }
            //Debug.Log("Damage " + modifiedDamage);

            return modifiedDamage; 
        } 
    }
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    public float AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }
    public List<SpellEffect> SpellEffects { get { return spellEffects; } }

    public UnitTeam Team { 
        get 
        {
            UnitTeam teamMod = team;

            foreach(SpellEffect effect in spellEffects)
            {
                if(effect.SpellEffectType == EffectType.Modifire)
                {
                    var modifire = effect as IModifire;

                    teamMod = modifire.TeamMod;
                }
            }

            return teamMod; 
        } 
        set { team = value; 
        } 
    }
    public UnitType UnitType { get { return unitType; } }

    public UnitBase()
    {
        spellEffects = new List<SpellEffect>();
    }

    public void TakeHit(float damage)
    {
        Health -= damage;
    }

    public void AddEffect(SpellEffect effect)
    {
        spellEffects.Add(effect);
    }

    public void SpellEffectsUpdate()
    {
        List<SpellEffect> endedEffects = new List<SpellEffect>();

        foreach (SpellEffect effect in spellEffects)
        {
            effect.OnUpdate();
            if(effect.DurationType == DurationType.Duration)
            {
                var duration = effect as IDuration;
                if (duration.TimeLeft <= 0)
                    endedEffects.Add(effect);
            }
        }

        foreach(SpellEffect effect in endedEffects)
        {
            if (effect.GetType() == typeof(MindControll))
                this.unitController.SelectTargetHero();

            spellEffects.Remove(effect);
        }
    }

    public void AddSpellEffect(SpellEffect effect)
    {
        spellEffects.Add(effect);
    }

    public void UseEffects(UnitBase target)
    {
        foreach(SpellEffect effect in spellEffects)
        {
            effect.OnUse(this, target);
        }
    }

    public bool CompareEffect(SpellEffect effect)
    {
        foreach(SpellEffect item in spellEffects)
        {
            if (effect == item) return true;
        }

        return false;
    }
}

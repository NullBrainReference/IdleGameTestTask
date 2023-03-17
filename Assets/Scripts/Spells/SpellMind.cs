using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpellMind : SpellBase, ICastable
{
    public SpellMind()
    {
        this.cooldown = 10;
        this.castType = CastType.Point;
        this.spellEffect = new MindControll();
    }

    void ICastable.Cast(UnitController unit)
    {
        Debug.Log("Cast - Mind");
        UnitController currController = unit;

        this.spellEffect.EffectReset();

        unit.Unit.AddSpellEffect(this.spellEffect);

        unit.SelectNewTarget();
    }
}

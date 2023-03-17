using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpellAsteroid : SpellBase, ICastable
{
    public SpellAsteroid()
    {
        this.cooldown = 10;
        this.castType = CastType.Area;
        this.spellEffect = new SpellEffect();

    }

    void ICastable.CastArea(Vector2 position)
    {
        List<UnitController> controllers = EnemiesManager.Instance.GetUnitsInRadius(position, 300);

        float fullDamage = 100 + (controllers.Count * 10);

        foreach(UnitController controller in controllers)
        {
            controller.Unit.TakeHit(fullDamage);
        }
    }

}

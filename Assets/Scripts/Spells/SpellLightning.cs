
using UnityEngine;

public class SpellLightning : SpellBase, ICastable
{
    public int charges;

    public SpellLightning()
    {
        this.cooldown = 5;
        this.castType = CastType.Point;
        this.spellEffect = new LightningEffect();
        this.charges = 6;
    } 

    void ICastable.Cast(UnitController unit)
    {
        UnitController currController = unit;
        unit.Unit.AddSpellEffect(this.spellEffect);

        unit.Unit.TakeHit(7);
        charges--;
        for (int i = 0; i < charges; i++)
        {
            currController = EnemiesManager.Instance.GetUnitInRadius(currController, 200, this.spellEffect);
            if (currController == null) return;

            currController.Unit.TakeHit(7);
            currController.Unit.AddSpellEffect(this.spellEffect);
            
            Debug.Log("Lightning charge " + currController.Unit.Health.ToString());
        }
    }
}

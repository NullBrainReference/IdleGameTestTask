using System;
using System.Threading.Tasks;

public enum DurationType { Infinate, Duration}

public enum EffectType { Modifire, OneTime}

public class SpellEffect
{
    private DurationType durationType;
    private EffectType effectType;

    public DurationType DurationType { get { return durationType; } set { durationType = value; } }
    public EffectType SpellEffectType { get { return effectType; } set { effectType = value; } }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnUse(UnitBase user, UnitBase enemy)
    {

    }

    public virtual void EffectReset()
    {

    }
}

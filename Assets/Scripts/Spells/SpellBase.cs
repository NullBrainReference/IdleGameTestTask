public enum CastType { Point, Area, Passive}

public class SpellBase
{
    protected CastType castType;
    protected SpellEffect spellEffect;
    protected float cooldown;

    public CastType CastType { get { return castType; } }
    public SpellEffect SpellEffect { get { return spellEffect; } }
    public float CoolDown { get { return cooldown; } }
}

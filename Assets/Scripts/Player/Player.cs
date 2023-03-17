using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{    
    private UnitHero unitHero;
    private List<SpellBase> spells;
    
    public UnitHero UnitHero { get { return unitHero; } }
    public List<SpellBase> Spells { get { return spells; } }
    
    public Player()
    {
        unitHero = new UnitHero();
        spells = new List<SpellBase>();
    }
}

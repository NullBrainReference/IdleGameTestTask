using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModifire
{
    public float HealthMod { get; set; }
    public float DamageMod { get; set; }
    public UnitTeam TeamMod { get; set; }
}

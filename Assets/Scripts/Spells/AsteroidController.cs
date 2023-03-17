using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : SpellController
{
    private void Awake()
    {
        spell = new SpellAsteroid();
    }
}

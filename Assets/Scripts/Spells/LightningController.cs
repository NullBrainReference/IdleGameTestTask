using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : SpellController
{
    

    private void Awake()
    {
        spell = new SpellLightning();
    }
}

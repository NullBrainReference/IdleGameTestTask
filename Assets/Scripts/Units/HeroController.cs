using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : UnitController
{
    [SerializeField] private GameObject restartScreen;

    private void Start()
    {
        Unit = new UnitHero();
        Unit.AddEffect(new BloodlustEffect());

        attackCooldown = Unit.AttackSpeed;
    }

    protected override void Die()
    {
        if (Unit.Health <= 0)
        {
            restartScreen.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}

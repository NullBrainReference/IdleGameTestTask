using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    protected NavMeshAgent agent;
    public Transform target;

    private UnitBase unit;
    private UnitBase currentEnemy;

    protected float attackCooldown;
    private float attackTime;

    public UnitBase Unit { get { return unit; } set { unit = value; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentEnemy != null) return;
        if (collision.CompareTag("Unit"))
        {
            UnitBase collisionUnit = collision.GetComponent<UnitController>().Unit;
            if(collisionUnit.Team != unit.Team)
                currentEnemy = collisionUnit;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (unit.UnitType != UnitType.Hero && collision.CompareTag("Unit"))
        {
            UnitBase collisionUnit = collision.GetComponent<UnitController>().Unit;
            if (collisionUnit.UnitType != UnitType.Hero && collisionUnit.Team == UnitTeam.Ally)
            {
                ForceToCangeTarget(collisionUnit.unitController);
            }
        }
        if (currentEnemy != null) return;
        if (collision.CompareTag("Unit"))
        {
            UnitBase collisionUnit = collision.GetComponent<UnitController>().Unit;
            if (collisionUnit.Team != unit.Team)
                currentEnemy = collisionUnit;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            if(currentEnemy == collision.GetComponent<UnitController>().Unit)
                currentEnemy = null;
        }
    }

    private void Start()
    {
        unit.unitController = this;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = unit.MovementSpeed;

        MoveTo(target);

        attackCooldown = unit.AttackSpeed;
    }

    private void FixedUpdate()
    {
        unit.SpellEffectsUpdate();

        if (currentEnemy != null)
        {
            if (attackTime <= 0) 
            { 
                Attack(currentEnemy);
                attackTime = attackCooldown;
            }
        }

        attackTime -= Time.deltaTime;
        
        Die();
    }

    public void MoveTo(Transform target)
    {
        agent.SetDestination(new Vector3(0, 0, 0));
        agent.stoppingDistance = 1;
    }

    public void Attack(UnitBase target)
    {
        this.unit.UseEffects(target);
        target.TakeHit(unit.Damage);
    }

    public void ForceToCangeTarget(UnitController target)
    {
        currentEnemy = target.unit;
        MoveTo(target.transform);
    }

    protected virtual void Die()
    {
        if (unit.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SelectNewTarget()
    {
        Vector3 newPos = EnemiesManager.Instance.GetClosestUnitInRadius(this, 300).transform.position;
        agent.SetDestination(
            newPos
        );
    }

    public void SelectTargetHero()
    {
        agent.SetDestination(EnemiesManager.Instance.heroController.transform.position);
    }
}

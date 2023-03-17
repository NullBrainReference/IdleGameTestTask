using UnityEngine;
using UnityEngine.UI;

public class SpellController : MonoBehaviour
{
    [SerializeField] protected Button button;

    public SpellBase spell;

    private float time = 0;

    public float CurrentTime { 
        get { return time; } 
        set 
        {
            time = value;
            if (time <= 0)
                time = 0;
        } 
    }

    private void FixedUpdate()
    {
        CurrentTime -= Time.deltaTime;
        if(CurrentTime <= 0)
        {
            button.interactable = true;
        }
    }

    public void Cast()
    {
        if (spell.CastType == CastType.Point)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Unit"))
                {
                    UnitController unit = hit.transform.GetComponent<UnitController>();
                    if (unit.Unit.UnitType == UnitType.Hero) return;
                    if (unit.Unit.UnitType == UnitType.ZombieBoss && this.spell.GetType() == typeof(SpellMind)) return;

                    ICastable castable = this.spell as ICastable;
                    castable.Cast(unit);

                    GoOnCooldown();
                }
            }
        }
        else if (spell.CastType == CastType.Area)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.point != null)
            {
                ICastable castable = this.spell as ICastable;
                castable.CastArea(hit.point);

                GoOnCooldown();
            }
        }
    }

    public void PrepareToCast()
    {
        SpellManager.Instance.CurrentSpell = this;
    }

    private void GoOnCooldown()
    {
        CurrentTime = spell.CoolDown;
        button.interactable = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public List<UnitController> unitControllers;

    public UnitController heroController;

    public static EnemiesManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        unitControllers = new List<UnitController>();
    }

    private void FixedUpdate()
    {
        foreach (UnitController controller in unitControllers)
        {
            if (controller == null)
            {
                unitControllers.Remove(controller);
                return;
            }

            if (controller.Unit.Health <= 0)
            {
                unitControllers.Remove(controller);
                return;
            }
        }
    }

    public UnitController GetUnitInRadius(UnitController target, float radius, SpellEffect avoidEffect)
    {
        foreach(var controller in unitControllers)
        {
            if (controller == target) continue;
            if(Vector2.Distance(target.transform.position, controller.transform.position) <= radius)
            {
                if (controller.Unit.CompareEffect(avoidEffect)) continue;
                
                return controller;
            }
        }

        return null;
    }

    public UnitController GetClosestUnitInRadius(UnitController target, float radius)
    {
        UnitController closestController = null;
        float minDist = radius;

        foreach (var controller in unitControllers)
        {
            if(controller == target) continue;
            float distance = Vector2.Distance(target.transform.position, controller.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                closestController = controller;
            }
        }

        return closestController;
    }

    public void AddController(UnitController controller) 
    {
        unitControllers.Add(controller);
    }

    public List<UnitController> GetUnitsInRadius(Vector2 position, float radius)
    {
        List<UnitController> result = new List<UnitController>();

        foreach (var controller in unitControllers)
        {
            if (Vector2.Distance(position, controller.transform.position) <= radius)
            {
                result.Add(controller);
            }
        }

        return result;
    }
}

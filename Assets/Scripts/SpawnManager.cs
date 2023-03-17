using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform spawnTarget;

    [SerializeField] private int unitsSpawned;
    [SerializeField] private int unitsBeforeBoss;

    [SerializeField] private float spawnRadius;

    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> bossPrefabs;
    [SerializeField] private Transform enemysParent;

    [SerializeField] private float spawnCoolDown;
    private float currentTme;

    private void FixedUpdate()
    {
        currentTme -= Time.deltaTime;

        if(currentTme <= 0)
        {
            SpawnAround(spawnTarget);

            CoolDownReset();
        }
    }

    public void SpawnAround(Transform target)
    {
        float x = Random.Range(-spawnRadius, spawnRadius);
        float y = Mathf.Sign(Random.Range(-1f, 1f)) * Mathf.Sqrt(spawnRadius * spawnRadius - x * x);

        Vector3 possInRadius = new Vector3(x, y, -1);
        Quaternion rotation = new Quaternion();

        ChooseAndSpawn(possInRadius, rotation);
    }

    private void ChooseAndSpawn(Vector3 pos, Quaternion rotation)
    {
        if (unitsSpawned < unitsBeforeBoss)
        {
            var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

            var enemy = Instantiate(prefab, pos, rotation, enemysParent);
            UnitController controller = enemy.GetComponent<UnitController>();
            controller.Unit = new UnitZombie();
            controller.target = spawnTarget;

            EnemiesManager.Instance.AddController(controller);

            unitsSpawned++;
        }
        else
        {
            var prefab = bossPrefabs[Random.Range(0, enemyPrefabs.Count)];

            var enemy = Instantiate(prefab, pos, rotation, enemysParent);
            UnitController controller = enemy.GetComponent<UnitController>();
            controller.Unit = new UnitZombieBoss();
            controller.target = spawnTarget;

            EnemiesManager.Instance.AddController(controller);

            unitsSpawned = 0;
        }
    }

    public void CoolDownReset()
    {
        currentTme = spawnCoolDown;
    }
}

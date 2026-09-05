using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EnemyType
{
    public string enemyName;
    public ObjectPool pool;
    public int weight;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 0.1f;
    [SerializeField] private float spawnRadius = 14f;
    [SerializeField] private List<EnemyType> enemyTypes;
    private float lastSpawnTime = -100f;

    private EnemyType PickWeightedEnemy()
    {
        int total = 0;
        foreach (EnemyType type in enemyTypes)
        {
            total += type.weight;
        }

        int roll = Random.Range(0, total);

        foreach (EnemyType type in enemyTypes)
        {
            roll -= type.weight;
            if (roll < 0)
            {
                return type;
            }
        }

        return enemyTypes[enemyTypes.Count - 1];
        
    }

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            lastSpawnTime = Time.time;

            // insideUnitCircle hands you a random point within the unit circle of radius 1 and .normalized pushes it out to the edge so its purely a direction
            Vector2 direction = Random.insideUnitCircle.normalized;

            //(Vector2) is a "cast" that tells the compiler to convert this value from one type to another. In this case, player.position is a Vector3, so we convert to Vector2
            Vector2 spawnPos = (Vector2)player.position + direction * spawnRadius;
            EnemyType chosen = PickWeightedEnemy();
            GameObject newEnemy = chosen.pool.Get();

            // if no more enemies in the pool, returns so code stops running
            if (newEnemy == null) return;

            newEnemy.transform.position = spawnPos;

            // gets the enemymovement script from the new game object created and calls the public Initialize method that sets the player's Transform as the target
            newEnemy.GetComponent<EnemyMovement>().Initialize(player);
        }
    }
}
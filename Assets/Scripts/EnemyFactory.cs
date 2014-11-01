using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawner for enemies. Attach to GameObject to spawn near (Player)
/// </summary>
public class EnemyFactory : MonoBehaviour
{
    // Object to instantiate in Create function
    public GameObject enemyObject;

    // Min/Max distance the enemy can spawn from the player
    public float minSpawnDistance;
    public float maxSpawnDistance;

    // Maximum number of concurrent enemies
    public int maxEnemies;

    // List of currently spawned enemies
    List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            CreateObject();
        else if (Input.GetKeyDown(KeyCode.F))
            KillObject();
    }

    // Creates an object of type (templateObject) at random position and facing
    // the player
    public void CreateObject()
    {
        if (enemies.Count >= maxEnemies)
        {
            // What do? Message box, simply return out, log error?
            return;
        }
        // Generate random position within defined thresholds
        Vector2 pt = Random.insideUnitCircle;
        pt.Normalize();
        float radius = Random.Range(minSpawnDistance, maxSpawnDistance);
        pt *= radius;
        Vector3 position = new Vector3(pt.x, 0, pt.y);

        // Generate quaternion facing the player
        Quaternion rotation = Quaternion.LookRotation(
            gameObject.transform.position - position);

        // Instantiate the enemy
        enemies.Add((GameObject)Instantiate(enemyObject, position, rotation));
    }

    public void KillObject()
    {
        if (enemies.Count == 0)
            return;

        int idx = Random.Range(0, enemies.Count - 1);
        GameObject go = enemies[idx];
        enemies.RemoveAt(idx);
        Destroy(go);
    }
}

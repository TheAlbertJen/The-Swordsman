using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour
{
    // Object to instantiate in Create function
    public GameObject enemyObject;

    // Player object (for rotation)
    public GameObject playerObject;

    // Min/Max distance the enemy can spawn from the player
    public float minSpawnDistance;
    public float maxSpawnDistance;

    // Maximum number of concurrent enemies
    public int maxEnemies;

    // List of currently spawned enemies
    List<GameObject> enemies;

    // Creates an object of type (templateObject) at random position and facing
    // the player
    public void CreateObject()
    {
        // Generate random position within defined thresholds
        Vector2 pt = Random.insideUnitCircle;
        float radius = Random.Range(minSpawnDistance, maxSpawnDistance);
        pt *= radius;
        Vector3 position = new Vector3(pt.x, 0, pt.y);
        
        // Generate quaternion facing the player
        Quaternion rotation = Quaternion.LookRotation(
            playerObject.transform.position - position);

        // Instantiate the enemy
        enemies.Add( (GameObject)Instantiate(enemyObject, position, rotation) );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Guzeldere, Jasmine
 * 12/10/2025
 * Handles spawning of the wave
 */
public class WaveManager : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float enemySpawnRate = 30f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawning", 1, enemySpawnRate);  
    }

    /// <summary>
    /// Spawns enemies
    /// </summary>
    private void EnemySpawning()
    {
        Instantiate(enemyToSpawn, transform.position, transform.rotation);
    }
}

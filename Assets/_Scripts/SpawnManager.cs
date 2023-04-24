using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playerCharacters;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> bossEnemies;
    GameObject[] spawnPoints;

    private int enemiesToSpawn = 3;
    private int wave = 0;
    private int enemySpawnIndex = 0;
    private int maxWaves = 5;


    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");

        int choice = CharacterSelect.playerChoice;
        Instantiate(playerCharacters[choice], Vector3.zero, Quaternion.identity);
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        wave++;
        int counter = 0;

        // Spawn an enemy at each spawn point on the map.
        while (counter < enemiesToSpawn)
        {
            // Create's a small variety of where the enemy will spawn near the spawn point
            Vector3 randomSpawnLocation = new Vector3(Random.Range(-15, 16), 0, Random.Range(-15, 16));

            yield return new WaitForSeconds(3/wave);
            foreach (GameObject spawnPoint in spawnPoints)
            {
                Instantiate(enemies[Random.Range(enemySpawnIndex, enemySpawnIndex + 2)], 
                    spawnPoint.transform.position + randomSpawnLocation, Quaternion.identity);
            }
            counter++;
        }
        enemiesToSpawn += 3;
        enemySpawnIndex += 2;

        yield return new WaitForSeconds(15);
        // Spawn the wave boss at a random spawn point
        Instantiate(bossEnemies[wave - 1], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].transform.position, Quaternion.identity);

        yield return new WaitForSeconds(15);

        // Start the next wave if the player hasnt reached the last wave. 
        if (wave != maxWaves)
        {
            StartCoroutine(SpawnEnemyWaves());
        }  
    }
}

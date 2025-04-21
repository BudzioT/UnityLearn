using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] bossPrefabs;
    public GameObject[] powerupPrefabs;

    private readonly float _spawnRange = 9f;
    private int _waveNumber = 1;
    
    private void Start()
    {
        SpawnEnemyWave(_waveNumber);
    }

    private void Update()
    {
        var enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(++_waveNumber);
            SpawnPowerup(1);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private void SpawnEnemyWave(int amount)
    {
        if (amount % 5 == 0)
        {
            int randomIndex = Random.Range(0, bossPrefabs.Length);
            Instantiate(bossPrefabs[randomIndex], GenerateSpawnPos(), bossPrefabs[randomIndex].transform.rotation);
        }
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPos(), enemyPrefabs[randomIndex].transform.rotation);
        }
    }

    public void SpawnXEnemies(int x)
    {
        for (int i = 0; i < x; i++)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPos(), enemyPrefabs[randomIndex].transform.rotation);
        }
    }

    private void SpawnPowerup(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomPowerupIndex = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomPowerupIndex], GenerateSpawnPos(), powerupPrefabs[randomPowerupIndex].transform.rotation);
        }
    }
}

using System;
using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int amountOfEnemies = 2;
    public float spawnSpeed = 3f;
    private SpawnManager _spawnManager;

    private void Start()
    {
        StartCoroutine(SpawnCooldown());
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(spawnSpeed);
        SpawnEnemies();
        StartCoroutine(SpawnCooldown());
    }

    private void SpawnEnemies()
    {
        _spawnManager.SpawnXEnemies(amountOfEnemies);
    }
}

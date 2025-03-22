using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float _lastSpawnTime;
    private const float SpawnDelay = 1.5f;

    private void Start()
    {
        _lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time - _lastSpawnTime) > SpawnDelay)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _lastSpawnTime = Time.time;
        }
    }
}

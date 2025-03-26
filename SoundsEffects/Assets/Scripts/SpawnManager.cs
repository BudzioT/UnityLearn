using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(25, 0, 0);
    
    private readonly float _startDelay = 2f;
    private readonly float _repeatRate = 2f;
    private PlayerController _playerController;
    
    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), _startDelay, _repeatRate);
    }

    private void SpawnObstacle()
    {
        if (_playerController.gameOver)
        {
            return;
        }
        
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}

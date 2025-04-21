using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Vector2 upForceRange = new Vector2(12, 16);
    public Vector2 torqueRange = new Vector2(-10, 10);
    public Vector2 spawnPosXRange = new Vector2(-4, 4);
    public float spawnPosY = -6;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(upForceRange.x, upForceRange.y);
    }

    private float RandomTorque()
    {
        return Random.Range(torqueRange.x, torqueRange.y);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(spawnPosXRange.x, spawnPosXRange.y), spawnPosY);
    }
}

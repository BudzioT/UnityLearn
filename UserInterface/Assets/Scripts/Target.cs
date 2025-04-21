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

    public int points = 0;
    public ParticleSystem explosionParticle;
    
    private GameManager _gameManager;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!_gameManager.isGameActive)
        {
            return;
        }
        
        Destroy(gameObject);
        _gameManager.UpdateScore(points);

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
            Debug.Log("DEAD");
        }
        
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

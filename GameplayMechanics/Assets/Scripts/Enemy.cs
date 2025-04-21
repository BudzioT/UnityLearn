using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    public GameObject player;
    public float speed;
    
    public static List<Enemy> Enemies = new List<Enemy>();

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        Enemies.Add(this);
    }

    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        _rigidbody.AddForce(speed * lookDirection);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            Enemies.Remove(this);
        }
    }
}

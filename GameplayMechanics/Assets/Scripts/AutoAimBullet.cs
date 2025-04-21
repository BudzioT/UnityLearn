using System;
using UnityEngine;

public class AutoAimBullet : MonoBehaviour
{
    public GameObject target;
    private Rigidbody _rigidbody;
    
    public float speed = 5f;
    public float hitStrength = 5f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Vector3 lookDirection = (target.transform.position - transform.position).normalized;
        transform.position += lookDirection;
    }

    private void LateUpdate()
    {
        if (!target)
        {
            Destroy(gameObject);
            return;
        } 
        
        Vector3 lookDirection = (target.transform.position - transform.position).normalized;
        _rigidbody.AddForce(speed * lookDirection);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 distanceFromBullet = other.transform.position - transform.position;
            
            enemyRb.AddForce(distanceFromBullet * hitStrength, ForceMode.Impulse);
        }
    }
}

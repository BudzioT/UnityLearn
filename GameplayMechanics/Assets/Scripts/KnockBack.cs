using System;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float power = 20f;
    public float maxDistance = 8f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                Vector3 direction = (other.gameObject.transform.position - transform.position);
                Vector3 normalizedDirection = direction.normalized;

                float distance = direction.magnitude;
                float distanceMultiplier = Mathf.Clamp01(1 - (distance / maxDistance));
                float scaledPower = power * (1 + distanceMultiplier * 2);
                
                Vector3 slamDirection = new Vector3(direction.x, 0.2f, direction.z).normalized;
                enemyRb.AddForce(slamDirection * scaledPower, ForceMode.Impulse);
            }
        }
    }
}

using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject powerupIndicator;
    public Vector3 powerupIndicatorOffset = new Vector3(0f, -0.5f, 0f);
    
    private Rigidbody _rigidbody;
    private GameObject _focalPoint;

    public GameObject bulletPrefab;
    private bool _readyToShoot = true;
    
    private bool _hasPowerup = false;
    private int _powerupIndex = 0;
    private readonly float _powerupStrength = 10f;

    public int slamsLeft = 0;
    public float jumpStrength = 700f;
    public bool _slamReady = false;
    public GameObject _slamArea;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
        _slamArea = GameObject.Find("SlamArea");
        _slamArea.gameObject.SetActive(false);
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(verticalInput * speed * _focalPoint.transform.forward);
        if (_hasPowerup)
        {
            powerupIndicator.transform.position = transform.position + powerupIndicatorOffset;
            if (_powerupIndex == 1)
            {
                if (_readyToShoot)
                {
                    foreach (var enemy in Enemy.Enemies)
                    {
                        GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                        bullet.GetComponent<AutoAimBullet>().target = enemy.gameObject;
                    }
                    
                    _readyToShoot = false;
                    StartCoroutine(ShootCooldown());
                }
            }

            if (Input.GetButtonDown("Jump") && slamsLeft > 0)
            {
                Slam();
                --slamsLeft;
                
                if (slamsLeft <= 0)
                {
                    _hasPowerup = false;
                    powerupIndicator.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            _hasPowerup = true;
            Destroy(other.gameObject);

            if (other.gameObject.name.Contains("Bullet"))
            {
                _powerupIndex = 1;
                powerupIndicator.SetActive(true);
                StartCoroutine(PowerupCountdown());
            }
            else if (other.gameObject.name.Contains("Slam"))
            {
                _powerupIndex = 2;
                powerupIndicator.SetActive(true);
                slamsLeft = 2;
            }
            else
            {
                _powerupIndex = 0;
                powerupIndicator.SetActive(true);
                StartCoroutine(PowerupCountdown());
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && _hasPowerup && _powerupIndex == 0)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 distanceFromPlayer = other.transform.position - transform.position;
            
            enemyRb.AddForce(distanceFromPlayer * _powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + other.gameObject.name + " with powerup");
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            if (_slamReady)
            {
                TurnKnockback();
            }
        }
    }

    private IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(7);
        _hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        _readyToShoot = true;
    }

    private IEnumerator SlamActivation()
    {
        yield return new WaitForSeconds(1f);
        _rigidbody.AddForce(Vector3.down * jumpStrength * 2);
        _slamReady = true;
        _slamArea.SetActive(true);
    }

    private void Slam()
    {
        _rigidbody.AddForce(Vector3.up * jumpStrength);
        StartCoroutine(SlamActivation());
    }
    
    private void TurnKnockback()
    {
        StartCoroutine(DeactivateKnocback());
    }

    private IEnumerator DeactivateKnocback()
    {
        yield return new WaitForSeconds(0.5f);
        _slamArea.SetActive(false);
        _slamReady = false;
    }
}

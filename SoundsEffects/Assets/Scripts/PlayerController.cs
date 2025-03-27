using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _isOnGround = true;
    private Animator _animator;
    private AudioSource _audio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
    public bool gameOver;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !gameOver)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            
            dirtParticle.Stop();
            _animator.SetTrigger("Jump_trig");
            _audio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _audio.PlayOneShot(crashSound, 1.0f);
        }
    }
}

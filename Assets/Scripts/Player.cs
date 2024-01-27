using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float thrust;
    public GameManager gm;
    private Animator _animator;
    public AudioClip hit;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()  
    {

        if (/*Input.GetMouseButton(0)*/ Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up *  thrust, ForceMode2D.Impulse);
            RotateSprite(7);
        }
        else
        {
            RotateSprite(-7);
        }
    }
    
    void RotateSprite(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Pipe") || other.collider.CompareTag("Border"))
        {
            _audioSource.PlayOneShot(hit);
            _animator.SetTrigger("death");
            gm.SetUpGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            _audioSource.PlayOneShot(hit);
            _animator.SetTrigger("death");
            Debug.Log("Border detected");
            gm.SetUpGameOver();
        }

        if (other.gameObject.CompareTag("PipeTrigger"))
        {
            gm.addScore();
        }
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] AudioClip shot;
    [SerializeField] float bulletSpeed =  20f;
    [SerializeField] float volume = 1.0f;

    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        myRigidbody= GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        //velocidad de x
        xSpeed = player.transform.localScale.x * bulletSpeed;
        AudioSource.PlayClipAtPoint(shot,Camera.main.transform.position,volume);

    }

    void Update()
    {
        myRigidbody.velocity= new Vector2(xSpeed,0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}


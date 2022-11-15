using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 death= new Vector2(10f,10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    SceneLoader sceneLoader;
    bool isAlive = true;
 
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void Update()
    {
        if(!isAlive){return;} //isnotalive
        Run();
        FlipSprite();
        Death();
    }

    void OnMove(InputValue value)
    {
        if(!isAlive){return;}
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        //Inicia running
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y); //y queda en 0 / x se multiplica runspeed
        myRigidbody.velocity = playerVelocity;

        //Cambia animacion de idle a running
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x)> Mathf.Epsilon;
        myAnimator.SetBool("isRunning",playerHasHorizontalSpeed);
    }

    void OnJump (InputValue value) 
    {
        if(!isAlive){return;}
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}  //si el boxcollider no esta tocando el layer Ground que siga al siguiente if
        if(value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f,jumpSpeed);
        }
    }

    void OnFire (InputValue value)
    {
        if(!isAlive){return;}
        Instantiate (bullet,gun.position, transform.rotation); 

    }
    void FlipSprite()
    {   
        //bool playertienevelocidadhorizontal?
        //Mathf.Abs regresa el valor absoluto de f
        //Mathf.Sign regresa el signo de f: regresa un 1 si f es positivo y un -1 si f es negativo
        //Mathf.Epsilon el valor mas pequeno que un float puede tener diferente a 0. Usado para no poner 0
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x)> Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x),1f);
        }
    }
    void Death()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazard")))
        {
            isAlive=false;
            myAnimator.SetTrigger("Dying");
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            Destroy(gameObject,2);

        }
    }
}

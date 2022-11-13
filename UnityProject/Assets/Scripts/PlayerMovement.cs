using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rigidBody;
    private bool mirandoDerecha = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(inputMovimiento*velocidad, rigidBody.velocity.y);
        Orientacion(inputMovimiento);
    }

    void Orientacion(float inputMovimiento)
    {
        if((mirandoDerecha = true && inputMovimiento<0)||(mirandoDerecha=false && inputMovimiento>0)  )
        {
            mirandoDerecha=!mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
        }
    }
}

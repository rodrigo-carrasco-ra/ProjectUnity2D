using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{   
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadSalto;
    private Rigidbody2D rb2d;
    float inputHorizontal;
    float inputVertical;
    private Animator anima;
    private bool en_suelo;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anima= gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");


        rb2d.velocity = new Vector2(inputHorizontal* velocidadMovimiento,rb2d.velocity.y);
        
        if (inputHorizontal>0){
            gameObject.transform.localScale = new Vector3(3,3,3);
        }

        else if (inputHorizontal<0){
            gameObject.transform.localScale = new Vector3(-3,3,3);
        }

        if(Input.GetKey(KeyCode.Space) && en_suelo)
            Saltar();
        //Parametros de Animator
        anima.SetBool("correr",inputHorizontal!=0);
        anima.SetBool("en_suelo",en_suelo);

    }    

    void Saltar()
    {
         rb2d.velocity = new Vector2(rb2d.velocity.x,velocidadSalto);
         anima.SetTrigger("salto_trigger");
         en_suelo = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag=="Suelo")
            en_suelo = true;
    }
}
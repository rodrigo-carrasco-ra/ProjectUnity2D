using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ValidarDatos : MonoBehaviour
{
    public Text CajaNombre, CajaEdad;
    string Nombre{get;set;}

    byte Edad{get;set;}

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Validar(){
        Nombre = CajaNombre.text;
       // try{
       //     Edad = byte.Parse(CajaEdad.text);
       // }
     //   catch(Exception ex){
       //     Debug.Log("Error: Edad no Valida");
     //       byte.TryParse(CajaEdad.text, out Edad);
        //}
       //
        SceneManager.LoadScene("Scene2");
        //Debug.Log("El valor es "+ Edad);
        Debug.Log($"El valor es {Edad}");


    }
}
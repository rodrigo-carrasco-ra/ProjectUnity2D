using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ValidarDatos : MonoBehaviour
{
    public Text CajaNombre, CajaEdad;  //variables
    string Nombre {get;set;}    //Lectura y escritura
    byte Edad {get;set;}
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  Validar(){
        Nombre = CajaNombre.text;  //text devulve String
        /*
        try{
            Edad = byte.Parse(CajaEdad.text);  //convierte en numero
        }
        catch(Exception ex){
            Debug.Log(ex.Message);
        }
     */
        SceneManager.LoadScene("Scene_3");
        Debug.Log("El valor es" + Edad);

    }
}

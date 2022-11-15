 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private InputField inputName;
    [SerializeField] private Text datos;
    private int age;
    private int requiredAge;
    void Awake() {
        datos.text = "Ingresa tus datos";
    }
    public void GetInput (string name, string age)
    {
        GetAge (int.Parse(age));
        inputName.text="";
    }

    void GetAge(int age){
        if (age >=18)
        {
            datos.text = "Edad adecuada para poder jugar";
        } else if (age<18){
            datos.text = "Edad no recomendada para poder jugar";

        }
    }
}

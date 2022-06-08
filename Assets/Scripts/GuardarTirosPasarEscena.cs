using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuardarTirosPasarEscena : MonoBehaviour
{
    public Text cantidadTiros;
    public Text mensajeDeError;

    int numeroDeTiros;

    private void Awake()
    {
        LoadData();
    }

    public void guardarCantidadDeTiros()
    {
        numeroDeTiros = int.Parse(cantidadTiros.text);

        if (cantidadTiros.text == "")
        {
            mensajeDeError.text = "El campo no puede estar vacio";
            Debug.Log("El campo no puede estar vacio");
        }

        else if (numeroDeTiros >= 30)
        {
            mensajeDeError.text = "Los tiros no pueden ser mas de 30";
        }

        else if (numeroDeTiros <= 0)
        {
            mensajeDeError.text = "Los tiros no pueden ser ni 0 ni menores a este";
        }

        else
        {
            SceneManager.LoadScene("Juego de Golf");
        }

    }


    private void OnDestroy()
    {
        SaveData(); // Cuando se destruya este objeto, en este caso cuando pasemos de script, guarda la informacion que seteamos en la funcion SaveData.
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Numero de Tiros", numeroDeTiros);
    }

    private void LoadData()
    {
        numeroDeTiros = PlayerPrefs.GetInt("Numero de Tiros", 0);
    }
}

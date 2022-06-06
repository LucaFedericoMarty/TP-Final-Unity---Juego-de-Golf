using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuardarTirosPasarEscena : MonoBehaviour
{
    public Text cantidadTiros;
    public Text mensajeDeError;

    public void guardarCantidadDeTiros()
    {
        int numeroDeTiros = int.Parse(cantidadTiros.text);

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
}

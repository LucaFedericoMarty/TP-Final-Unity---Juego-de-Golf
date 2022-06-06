using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSC : MonoBehaviour
{
    public void VolverInicio()
    {
        SceneManager.LoadScene("Inicio de Juego");
    }
}

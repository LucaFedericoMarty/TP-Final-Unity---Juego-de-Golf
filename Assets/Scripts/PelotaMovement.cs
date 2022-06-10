using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PelotaMovement : MonoBehaviour
{
    //Variable Bool
    bool ganaste;
    bool isPressing;

    // Variables Int
    int cantidadDeTiros;

    // Variable Float
    float timeElapsed;
    public  float rotation;
    public float translation;
    Rigidbody rb;

    public Text contadorTiempo;
    public Text contadorTiros;
    int contadorDeTiros;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isPressing = false;
        ganaste = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        contadorTiempo.text = Mathf.Floor(timeElapsed).ToString();

        rotation *= Time.deltaTime;
        translation *= Time.deltaTime;

        cantidadDeTiros = PlayerPrefs.GetInt("Numero de Tiros");
        contadorDeTiros = cantidadDeTiros;
        contadorTiros.text = contadorDeTiros.ToString();

        transform.eulerAngles += new Vector3(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * translation, ForceMode.Impulse);
            contadorDeTiros--;
        }


        if (transform.position.y < 0 && contadorDeTiros > 0)
        {
            ganaste = true;
        }

        else if (cantidadDeTiros > 10)
        {
            ganaste = false;
        }

        if (ganaste)
        {
            SceneManager.LoadScene("Ganaste");
        }

        else if (ganaste == false)
        {
            SceneManager.LoadScene("Perdiste");
        }


        ///transform.eulerAngles -= new Vector3(0, 0, horizonatlSpeed);

        // Si el click izquierdo es presionado, poner a isPressing como true

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{           
        //    isPressing = true;
        //}

        // Si se esta presionando el click izquierdo:
        // Contar el tiempo por cuanto lo hizo
        // Trackear cual fue el movimiento del mouse en el Eje X, luego multiplicar este valor por la velocidad de rotacion
        // Trackear cual fue el movimiento del mouse en el Eje Y, luego multiplicar este valor por la velocidad de traslacion

        //if (isPressing == true)
        //{
        //    timeElapsed += Time.deltaTime;
        //    rotation = horizonatlSpeed * Input.GetAxis("Mouse X");
        //    translation = verticalSpeed * Input.GetAxis("Mouse Y");
        //}

        //// Si dejo de presionar el click izquierdo:
        //// La variable que monitorea el estado del click se torna falsa
        //// Se multiplica tanto el valor de rotacion como de traslacion por Time.DeltaTime, para que la velocidad no dependa de los FPS
        //// Se ejecuta el tiro

        //if (Input.GetKeyUp(KeyCode.Mouse0))
        //{
        //    rotation *= Time.deltaTime;
        //    translation *= Time.deltaTime;
        //    //transform.eulerAngles += new Vector3(0, 0, rotation);
        //    //transform.Translate(translation, 0, 0);
        //    rb.AddForce(transform.eulerAngles += new Vector3(0,0, rotation) * translation,ForceMode.Impulse);
        //    //rb.AddForce(0, 0, translation);
        //    isPressing = false;
        //    timeElapsed = 0;
        //    contadorDeTiros++;
        //    // Hacer el movimiento con variables inresadas por el usuario
        //}

    }
}

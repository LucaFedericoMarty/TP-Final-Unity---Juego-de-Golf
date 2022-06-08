using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PelotaMovement : MonoBehaviour
{
    //Variable Bool
    bool ganaste;
    bool isPressing;

    // Variables Int
    int cantidadDeTiros;
    int contadorDeTiros;

    // Variable Float
    float timeElapsed;
    public float horizonatlSpeed;
    public float verticalSpeed;
    public  float rotation;
    public float translation;


    Rigidbody rb;

    public Text contadorTiempo;
    public Text contadorTiros;

    public GameObject CameraPelota;

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
        cantidadDeTiros = PlayerPrefs.GetInt("Numero de Tiros");

        cantidadDeTiros = contadorDeTiros;

        contadorTiros.text = contadorDeTiros.ToString();

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(horizonatlSpeed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles -= new Vector3(horizonatlSpeed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.AddForce(verticalSpeed, 0, 0);
            timeElapsed = 0;
            contadorDeTiros--;
        }

        // Si el click izquierdo es presionado, poner a isPressing como true

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{           
        //    isPressing = true;
        //}

        //// Si se esta presionando el click izquierdo:
        //// Contar el tiempo por cuanto lo hizo
        //// Trackear cual fue el movimiento del mouse en el Eje X, luego multiplicar este valor por la velocidad de rotacion
        //// Trackear cual fue el movimiento del mouse en el Eje Y, luego multiplicar este valor por la velocidad de traslacion

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
        //}


        if (transform.position.y < 0 && contadorDeTiros <= cantidadDeTiros )
        {
            ganaste = true;
        }

        else if (cantidadDeTiros > 10)
        {
            ganaste = false;
        }

        if (ganaste)
        {

        }
        
    }
}

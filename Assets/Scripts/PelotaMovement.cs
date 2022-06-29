using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PelotaMovement : MonoBehaviour
{
    //Variable Bool
    bool isPressing;
    public bool entroPelota;

    // Variables Int
    int cantidadDeTiros;
    int contadorDeTiros;

    // Variable Float
    float timeElapsed;
    public  float rotation;
    public float translation;
    //float horizontalSpeed;

    Vector3 constMov;

    // Componente rigidbody de la Pelota
    Rigidbody rb;

    // Los textos que van a mostrar los tiros y tiempo restante 
    public Text contadorTiempo;
    public Text contadorTiros;

    public GameObject prefabPelotitas;

    // Traigo el script de tocaGanas para agarrar el valor de una variable
    public tocaGanas tG;

    // Declaro las camaras para activarlas posteriormente

    public Camera CamPasto;
    public Camera CamHielo;
    public Camera CamArena;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Agarro el componente RigidBody de mi Script
        //isPressing = false; Variable que no utilizo mas, pero la conservo para ver si en el futuro puedo cambiar la mecanica del funcionamiento del tiro
        cantidadDeTiros = PlayerPrefs.GetInt("Numero de Tiros"); // Agarro el valor que se ingreso en el scrpit de GuardarTirosPasarEscena y lo guardo en una variable local
        contadorDeTiros = cantidadDeTiros; // Le guardo el valor de los tiros totales a una variable que va a iniciar con ese valor, para luego ir sabiendo la cantidad de tiros que tiene

        //horizontalSpeed = 5f;

        GameObject clon;

        for (int i = 0; i < cantidadDeTiros; i++)
        {
            clon = Instantiate(prefabPelotitas);
            clon.transform.Translate(-7, 5, i);
            Destroy(clon, 2);
        }

        CamPasto.enabled = true;
        CamHielo.enabled = false;
        CamArena.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime; // Cuento el tiempo que paso desde que se inicio el programa y lo guardo en una variable
        contadorTiempo.text = Mathf.Floor(timeElapsed).ToString(); // Al tiempo que paso, lo voy redondeando y se paso a una variable de texto, para que vaya mostrando por pantalla cuanto tiempo paso

        //rotation *= Time.deltaTime;
        //translation *= Time.deltaTime;

        contadorTiros.text = contadorDeTiros.ToString(); // Hago que la variable que cuente los tires se convierta a String, para que asi le podamos pasar esta informacion a una variable de texto que va a mostrar por pantalla la cantidad de tiros restantes

        //translation = horizontalSpeed * Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, rotation, 0);
        }

        // Si toca la letra A, la rotacion de la pelota aumenta en el eje Y.

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles -= new Vector3(0, rotation, 0);
        }

        // Si toca la letra A, la rotacion de la pelota disminuye en el eje Y.

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * translation, ForceMode.Impulse);
            //rb.AddForce(transform.forward * -translation, ForceMode.Impulse);
            //rb.AddForce(translation, 0, -rotation, ForceMode.Impulse);
            //rb.AddForce(new Vector3(Input.GetAxis("Vertical")) * .5, ForceMode.VelocityChange);
            //rb.AddForce(new Vector3(1,0,0) * translation, ForceMode.Impulse);
            //rb.AddForce(translation, 0, -rotation);
            contadorDeTiros--;
            timeElapsed = 0;
        }

        // Si toca tanto la el click izquierdo como la tecla de espacio, el tiro se ejecuta
        // Ademas, le resta un tiro puesto que ya se hizo uno
        // Por ultimo, reinicia el contador de tiempo restante

        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //   translation = 0;
        //}

        if (entroPelota == true && contadorDeTiros > 0)
        {
            SceneManager.LoadScene("Ganaste");
        }

        // Si la pelota hizo colision con el objeto designado y si la cantidad de tiros que lleva es mayor a 0, entonces gano, por lo que lo llevamos a la scene de Ganaste

        if (contadorDeTiros == -1)
        {
            SceneManager.LoadScene("Perdiste");
        }

        // Si se le acaban lo tiros, vamos a la escena de que perdio

        if (timeElapsed > 30)
        {
            SceneManager.LoadScene("Perdiste");
        }

        // De igual manera, si tardo mas de 30 segundos por tiro, perdio

        entroPelota = tG.entro; // Igualo el valor del bool que recibo del otro script para saber si hubo o no colision. Este valor lo igualo en una variable



        // INTENTO FALLIDO DE MECANICA DE TIRO


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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Hielo")
        {
            translation += 0.8f;
        }


        if (col.gameObject.name == "Arena")
        {
            translation -= 0.5f;
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Pasto")
        {
            CamPasto.enabled = true;
        }

        if (col.gameObject.name == "Hielo")
        {
            CamPasto.enabled = false;
            CamHielo.enabled = true;
        }


        if (col.gameObject.name == "Arena")
        {
            CamHielo.enabled = false;
            CamArena.enabled = true;
        }
    }
}

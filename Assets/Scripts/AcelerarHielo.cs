using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerarHielo : MonoBehaviour
{
    public float verticalSpeedIncreased;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PelotaMovement variableVelocidad = GetComponent<PelotaMovement>(); // Invoco al scrpit del cual quiero sacar la velocidad de la pelota, le asigno un nombre, y mediante el GetComponent, puede acceder a todos sus datos
        verticalSpeedIncreased = variableVelocidad.translation + 0.5f; // A la variable creada en este script, le doy el valor de la velocidad de la pelota establecido en el otro scrpit. Ademas, le sumo 0.5 para que su velocidad sea mayor en este caso.
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Pelota de Golf")
        {

        }

    }
}

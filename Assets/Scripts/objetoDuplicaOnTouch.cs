using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoDuplicaOnTouch : MonoBehaviour
{
    public GameObject obstaculoMultiplicador;
    //float separacion = -0.1391141f;
    float separacion;

    // Start is called before the first frame update
    void Start()
    {
        separacion = obstaculoMultiplicador.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        int counter = 0;
        GameObject clon;

        if (col.gameObject.name == "Pelota de Golf")
        {
            if (counter < 3)
            {
                clon = Instantiate(obstaculoMultiplicador);
                separacion = separacion + 0.15f;
                clon.transform.position = new Vector3(clon.transform.position.x, clon.transform.position.y, separacion);
                counter++;
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoDuplicaOnTouch : MonoBehaviour
{
    public GameObject obstaculoMultiplicador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        int counter = 0;
        float separacion = -0.5f;
        GameObject clon;

        if (col.gameObject.name == "Pelota de Golf")
        {
            if (counter < 3)
            {
                clon = Instantiate(obstaculoMultiplicador);
                clon.transform.Translate(clon.transform.position.x, 0.356f, separacion);
                counter++;
                separacion = separacion + 0.5f;
            }
            
        }
    }
}

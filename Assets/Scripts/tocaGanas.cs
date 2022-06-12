using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocaGanas : MonoBehaviour
{
    public bool entro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collider ball)
    {
        if (ball.gameObject.name == "Pelota de Golf")
        {
            Debug.Log("Toco");
            entro = true;
        }
    }
}

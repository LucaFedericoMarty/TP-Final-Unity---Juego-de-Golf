using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerarHielo : MonoBehaviour
{
    public float verticalSpeedIncreased;

    PelotaMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeedIncreased = pm.translation + 0.5f;
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Pelota de Golf")
        {

        }

    }
}

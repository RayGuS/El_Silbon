using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaSombra : MonoBehaviour
{
    public Transform jugador;
    

    Vector3 direction;

    float velRotation = 6f;
    float velcazaa = 15f;
   

    void Update()
    {
        direction = jugador.position - this.transform.position;
        if (Vector3.Distance(jugador.position - this.transform.position, this.transform.position) < 50)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), velRotation * Time.deltaTime);
            if (Vector3.Distance(jugador.position - this.transform.position, this.transform.position) > 2)
            {
                this.transform.Translate(0, 0, velcazaa * Time.deltaTime);
            }
            
        }


    }
}

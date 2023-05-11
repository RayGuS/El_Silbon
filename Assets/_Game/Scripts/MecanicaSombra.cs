using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaSombra : MonoBehaviour
{
    private Transform jugador;

    private GameObject[] o;

    Vector3 direction;

    float velRotation = 2f;
    float velcazaa = 1f;

    Animator animSombra;
    public DestruirSombra Dead;

    void Start()
    {
        Dead = GameObject.FindGameObjectWithTag("Luz").GetComponent<DestruirSombra>();
        animSombra = GetComponent<Animator>();
        o = GameObject.FindGameObjectsWithTag("Player");
        jugador = o[0].transform;
 
    }


    void Update()
    {
        direction = jugador.position - this.transform.position;
        if (Vector3.Distance(jugador.position - this.transform.position, this.transform.position) < 50)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), velRotation * Time.deltaTime);
            if (Vector3.Distance(jugador.position - this.transform.position, this.transform.position) > 4f)
            {
                this.transform.Translate(0, 0, velcazaa * Time.deltaTime);
                animSombra.SetBool("Caminar", true);
                animSombra.SetBool("Atacar", false);
                animSombra.SetBool("Morir", false);
            }
            else 
            {
                animSombra.SetBool("Caminar", false);
                animSombra.SetBool("Atacar", true);
                animSombra.SetBool("Morir", false);
            }
            
        }

        if (Dead.muerteSombra == true)
        {
            animSombra.SetBool("Caminar", false);
            animSombra.SetBool("Atacar", false);
            animSombra.SetBool("Morir", true);
        }


    }
}

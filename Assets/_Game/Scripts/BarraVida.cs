using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BarraVida : MonoBehaviour
{
    public Image barraVida;
    public BarraCordura cordura;
    public int daño;
    public float vidaMax;
    public float vidaActual;
    public bool defeat;
    public float periodoRevision = 1;
    public bool bajarVida;


    void Start()
    {

        StartCoroutine(BajarVida());

    }



    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Sombra")
        {
            bajarVida = true;
            if (vidaActual == 0)
            {
                defeat = true;
            }
        }
        else
        {
            bajarVida = false;
        }
    }



    public IEnumerator BajarVida()
    {
        while (true)
        {
            yield return new WaitForSeconds(periodoRevision);

            if (bajarVida == true)
            {
                vidaActual = vidaActual - daño ;
                barraVida.fillAmount = vidaActual / vidaMax;
            }
        }
    }
}
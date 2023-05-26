using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BarraVida : MonoBehaviour
{
    public Image barraVida;
    public BarraCordura cordura;
    public int da�o;
    public float vidaMax;
    public float vidaActual;
    public bool defeat;
    public float periodoRevision = 0.5f;
    public bool bajarVida;


    void Start()
    {

        StartCoroutine(BajarVida());

    }

    private void Update()
    {
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
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
                vidaActual = vidaActual - da�o ;
                barraVida.fillAmount = vidaActual / vidaMax;
            }
        }
    }
}
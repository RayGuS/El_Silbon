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

    void OnTriggerStay (Collider other)
    {
        
        if (other.tag == "Sombra")
        {
            vidaActual = vidaActual - da�o * Time.deltaTime;
            barraVida.fillAmount = vidaActual / vidaMax;
            if (vidaActual == 0)
            {
                defeat = true;
            }
        }
    }
}

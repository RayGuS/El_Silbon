using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image barraVida;
    public BarraCordura cordura;
    public int daño;
    public float vidaMax;
    public float vidaActual;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Sombra")
        {
            vidaActual = vidaActual - daño;
            barraVida.fillAmount = vidaActual / vidaMax;
        }
    }
}

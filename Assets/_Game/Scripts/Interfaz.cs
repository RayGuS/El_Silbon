using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class Interfaz : MonoBehaviour
{
    public GameObject victoria;
    public GameObject gameOver;

    public BarraVida vida;

    public void Victoria()
    {
        if (vida.defeat == false)
        {
            victoria.SetActive(true);
        }
        else
        {
            gameOver.SetActive(true);
        }
    }


}

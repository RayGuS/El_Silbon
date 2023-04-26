using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    //public GameObject Linterna;
    public bool activLight;
    public float cantBateria = 100;
    public TMP_Text porcentaje;
    public float perdidaBateria = 0.5f;

    void Update()
    {
        cantBateria = Mathf.Clamp(cantBateria, 0, 100);
        int valorBateria = (int)cantBateria;
        porcentaje.text = valorBateria.ToString() + "%";

        if (Input.GetKeyDown("f"))
        {
            activLight = !activLight;
            if(activLight == true)
            {
                luzLinterna.enabled = true;
               // Linterna.SetActive(true);
            }
            if (activLight == false)
            {
                luzLinterna.enabled = false;
               // Linterna.SetActive(true);
            }
        }

        if(activLight == true && cantBateria >0)
        {
            cantBateria -= perdidaBateria * Time.deltaTime;
        }
    }
}

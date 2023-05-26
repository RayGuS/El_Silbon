using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    //public GameObject Linterna;
    public bool activLight;
    public float cantBateria = 100;
    public float perdidaBateria = 0.5f;
    public Image linterna;
    public float cantBateriaActual = 100;
    public float cantBateriaMax = 100;

    private void Start()
    {
      luzLinterna.enabled = false;
    }

    void Update()
    {
        cantBateria = Mathf.Clamp(cantBateria, 0, 100);

        if (Input.GetKeyDown("l"))
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
            linterna.fillAmount = cantBateriaActual / cantBateriaMax;
            cantBateria -= perdidaBateria * Time.deltaTime;
        }
    }
}

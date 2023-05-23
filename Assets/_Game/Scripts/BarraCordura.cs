using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraCordura : MonoBehaviour
{
    public Image barraCordura;

    public float corduraMax;
    public float corduraActual;
    public bool luz = false;

    void Update()
    {
            
        if (luz == false && corduraActual>0 )
        {
            corduraActual -= Time.deltaTime;
            barraCordura.fillAmount = corduraActual / corduraMax;
        }

        if (luz == true && corduraActual<corduraMax)
        {
            corduraActual += Time.deltaTime;
            barraCordura.fillAmount = corduraActual / corduraMax;
        }


    }

    void OnTriggerStay(Collider other)
    {
        //print(other.tag);
        if (other.gameObject.tag == "Luz")
        {
            luz = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Luz")
        {
            luz = false;
        }
    }
}

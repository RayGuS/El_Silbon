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

    public Image efectoCordura;

    private float r;
    private float g;
    private float b;
    private float a;

    void Start()
    {
            r = efectoCordura.color.r;
            g = efectoCordura.color.g;
            b = efectoCordura.color.b;
            a = efectoCordura.color.a;
            a = 0;
   
    }

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

        a = Mathf.Clamp(a, 0, 1f);
        ChangeColor();

        if (corduraActual <= 17)
        {
            a += 0.001f;

        }
        else
        {
            a -= 0.01f;
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

    private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        efectoCordura.color = c;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silbido : MonoBehaviour
{

    public Vector2 tiempo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EsperarSilbido());
    }

    public void Silbar()
    {
        Debug.Log("HI");
    }

    IEnumerator EsperarSilbido()
    {
        float tiempoEspera = Random.Range(tiempo.x, tiempo.y);
        yield return new WaitForSeconds(tiempoEspera);
        Silbar();
        StartCoroutine(EsperarSilbido());
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombra : MonoBehaviour
{
    public GameObject sombra;
    public BarraCordura cordura;
    public BarraVida vida;
    public float condicion;
    public float periodoRevision = 5;
  
    void Start()
    {

        StartCoroutine(InstanciarSombra());
        
    }

    public IEnumerator InstanciarSombra()
    {
        while (true)
        {
            yield return new WaitForSeconds(periodoRevision);

            if (cordura.corduraActual < condicion && vida.defeat == false)
            {
                Vector3 posAleatoria = new Vector3(Random.Range(-5, 5), 2, Random.Range(-5, 5));
                Instantiate(sombra, posAleatoria, sombra.transform.rotation);
            }


        }
    }
}

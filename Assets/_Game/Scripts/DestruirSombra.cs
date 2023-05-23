using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirSombra : MonoBehaviour
{
    public IASombra sombra;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Sombra")
        {
            Destroy(other.gameObject,4);
            Debug.LogWarning("sombra entra");
            sombra.Morir();
        }
    }
}

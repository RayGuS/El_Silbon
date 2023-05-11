using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirSombra : MonoBehaviour
{
    public bool muerteSombra;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Sombra")
        {
            Destroy(other.gameObject, 2);
            muerteSombra = true;
        }
    }
}

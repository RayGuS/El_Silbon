using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirSombra : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Luz")
        {
            Destroy(this);
        }
    }
}

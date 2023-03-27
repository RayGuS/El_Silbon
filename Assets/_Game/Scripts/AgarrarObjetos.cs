using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    public GameObject objetoAgarrado;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoAgarrado.SetActive(true);
            gameObject.SetActive(false);
            anim.SetBool("Holding", true);
        }
    }
}

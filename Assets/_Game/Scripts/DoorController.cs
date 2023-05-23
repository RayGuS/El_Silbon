using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator DoorPivoting = null;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorPivoting.Play("JueputaMalparido", 0, 0.0f);
            Debug.Log("Abriendo");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorPivoting.Play("JueputaMalparidoClosing", 0, 0.0f);
            Debug.Log("Cerrando");


        }
    }
}
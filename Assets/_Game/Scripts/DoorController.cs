using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator Door = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                Door.Play("DoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {
                Door.Play("DoorClose", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
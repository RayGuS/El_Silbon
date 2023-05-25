using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator DoorPivoting = null;

    private ControladorSonidos controlSonido;

    private void Start()
    {
        controlSonido = FindObjectOfType<ControladorSonidos>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorPivoting.Play("OpenDoor", 0, 0.0f);
            controlSonido.EscogerAudio(5, TiposSonidos.Fx);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorPivoting.Play("CloseDoor", 0, 0.0f);
            controlSonido.EscogerAudio(6, TiposSonidos.Fx);
        }
    }
}
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgarrarObjetosPesados : MonoBehaviour
{
    public GameObject objetoPruebaPesado;
    public Animator anim;
    public Transform ObjetoPruebaPesadoParent;
    public InputAction Grab, Drop;
    public PlayerInput _playerInput;
    public ThirdPersonController _thirdPersonController;
    public CrouchControl CrouchScript;
    private float GrabmoveSpeed = 0.5f;
    private float moveSpeed;
    private float sprintSpeed;
   
    void Start()
    {
        objetoPruebaPesado.GetComponent<Rigidbody>().isKinematic = true;
        Grab.Enable();
        Drop.Enable();
        moveSpeed = _thirdPersonController.MoveSpeed;
        sprintSpeed = _thirdPersonController.SprintSpeed;
    }

    void Update()
    {
        bool isFKeyHeld = _playerInput.actions["Drop"].ReadValue<float>() > 0.5f;
        if (isFKeyHeld)
        {
            DropObj();
        }
    }

    public void GrabObj()
    {
        PlayerController.singleton.isHolding = true;

        objetoPruebaPesado.GetComponent<Rigidbody>().isKinematic = true;

        CrouchScript.enabled = false;

        _thirdPersonController.MoveSpeed = GrabmoveSpeed;
        _thirdPersonController.SprintSpeed = moveSpeed;

        objetoPruebaPesado.transform.position = ObjetoPruebaPesadoParent.transform.position;
        objetoPruebaPesado.transform.rotation = ObjetoPruebaPesadoParent.transform.rotation;

        objetoPruebaPesado.GetComponent<BoxCollider>().enabled = false;

        objetoPruebaPesado.transform.SetParent(ObjetoPruebaPesadoParent);

        anim.SetBool("HoldingHeavy", true);
    }

    public void DropObj()
    {
        PlayerController.singleton.isHolding = false;

        ObjetoPruebaPesadoParent.DetachChildren();
        objetoPruebaPesado.transform.eulerAngles = new Vector3(objetoPruebaPesado.transform.position.x, objetoPruebaPesado.transform.position.z, objetoPruebaPesado.transform.position.y);
        objetoPruebaPesado.GetComponent<Rigidbody>().isKinematic = false;
        objetoPruebaPesado.GetComponent<BoxCollider>().enabled = true;

        CrouchScript.enabled = true;

        _thirdPersonController.MoveSpeed = moveSpeed;
        _thirdPersonController.SprintSpeed = sprintSpeed;

        anim.SetBool("HoldingHeavy", false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && !PlayerController.singleton.isHolding)
        {
            bool isEKeyHeld = _playerInput.actions["Grab"].ReadValue<float>() > 0.5f;
            if (isEKeyHeld)
            {
                GrabObj();
            }
        }
    }
}

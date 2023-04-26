using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class AgarrarObjetos : MonoBehaviour
{
    public GameObject objetoPrueba;
    public Animator anim;
    public Transform ObjetoPruebaParent;
    public InputAction Grab, Drop;
    public PlayerInput _playerInput;

    void Start()
    {
        objetoPrueba.GetComponent<Rigidbody>().isKinematic = true;
        Grab.Enable();  
        Drop.Enable();
    }

    void Update () 
    {
     bool isFKeyHeld = _playerInput.actions["Drop"].ReadValue<float>() > 0.5f; 
      if (isFKeyHeld)
        {
            DropObj();
        }
    }

    public void DropObj()
    {
        ObjetoPruebaParent.DetachChildren();
        objetoPrueba.transform.eulerAngles = new Vector3(objetoPrueba.transform.position.x, objetoPrueba.transform.position.z, objetoPrueba.transform.position.y);
        objetoPrueba.GetComponent<Rigidbody>().isKinematic = false;
        objetoPrueba.GetComponent <SphereCollider>().enabled = true;
        anim.SetBool("Holding", false);
    }

    public void GrabObj()
    {
        objetoPrueba.GetComponent<Rigidbody>().isKinematic = true;

        objetoPrueba.transform.position = ObjetoPruebaParent.transform.position;
        objetoPrueba.transform.rotation = ObjetoPruebaParent.transform.rotation;

        objetoPrueba.GetComponent<SphereCollider>().enabled = false;

        objetoPrueba.transform.SetParent(ObjetoPruebaParent);
        anim.SetBool("Holding", true);
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            bool isEKeyHeld = _playerInput.actions["Grab"].ReadValue<float>() > 0.5f;
            if (isEKeyHeld)
            {
                GrabObj();
            }
        }
    }   
}

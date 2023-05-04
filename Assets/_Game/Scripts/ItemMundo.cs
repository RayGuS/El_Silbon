using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemMundo : MonoBehaviour
{

    public int cantidad;
    public int ID;
    public Inventario inv;
    public bool acumulable;

    public InputAction GrabItem;
    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        GrabItem.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          //  bool isJKeyHeld = playerInput.actions["GrabItem"].ReadValue<float>() > 0.5f;
          //  if (isJKeyHeld)
          //  {
                inv.AgregarItem(ID, cantidad);
          //  }
        }
    }

}

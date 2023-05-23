using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CPJugador : MonoBehaviour
{
    private bool bloqueo;
    public GameObject inventario;
    public InputAction OpenInventory;
    public InputActionProperty inpAbrirIventario;

    // Start is called before the first frame update
    void Start()
    {

        OpenInventory.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        if (inpAbrirIventario.action.ReadValue<float>()>0.5f && !bloqueo)
        {
            bloqueo = true;
            AbrirInventario();
        }
        if (inpAbrirIventario.action.ReadValue<float>() < 0.5f)
        {
            bloqueo = false;
        }
    }

    public void AbrirInventario()
    {

        Cursor.lockState = CursorLockMode.None;

            inventario.SetActive(!inventario.activeInHierarchy);
            inventario.transform.parent.position = inventario.GetComponent<Inventario>().posOriginal;

        if (!inventario.activeInHierarchy && inventario.GetComponent<Inventario>().objetoSeleccionado != null)
        {
            inventario.GetComponent<Inventario>().objetoSeleccionado.transform.SetParent(inventario.GetComponent<Inventario>().padreAnt);
            inventario.GetComponent<Inventario>().objetoSeleccionado.transform.localPosition = Vector3.zero;
            inventario.GetComponent<Inventario>().objetoSeleccionado = null;
        }

    }
}

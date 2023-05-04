using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CPJugador : MonoBehaviour
{

    public GameObject inventario;
    public InputAction OpenInventory;
    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(AbrirInventario());
        OpenInventory.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        bool isIKeyHeld = playerInput.actions["OpenInventory"].ReadValue<float>() > 0.5f;
        if (isIKeyHeld)
        {
            StartCoroutine(AbrirInventario());
        }
    }

    public IEnumerator AbrirInventario()
    {
        yield return new WaitForSeconds(1f);

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

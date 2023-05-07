using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcionEliminar : MonoBehaviour
{
    [SerializeField]
    Inventario inv;
    public Slider deslizador;
    public Text tCantidad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Eliminar();
    }

    public void Eliminar()
    {
        //yield return new WaitForSeconds(1f);
        if (this.gameObject.activeInHierarchy)
        {
            deslizador.maxValue = inv.osc;
            tCantidad.text = deslizador.value.ToString();
        }
    }

    public void Aceptar()
    {
        inv.EliminarItem(inv.osid, Mathf.RoundToInt(deslizador.value));
        deslizador.value = 1;
        this.gameObject.SetActive(false);
    }

    public void Cancelar()
    {
        deslizador.value = 1;
        this.gameObject.SetActive(false);
    }

}

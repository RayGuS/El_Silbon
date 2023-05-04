using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int cantidad = 1;
    public int ID;

    public bool acumulable;
    public Button Boton;
    public GameObject descripcion;
    public BaseDatos baseDAtos;
    public Vector3 desfase;

    public Text tCantidad;
    public Text tNombre;
    public Text tDescripcion;



    // Start is called before the first frame update
    void Start()
    {
        acumulable = baseDAtos.baseDatos[ID].acumulable;
        Boton = GetComponent<Button>();
        descripcion = Inventario.descripcion;
        tNombre = descripcion.transform.GetChild(0).GetComponent<Text>();
        tDescripcion = descripcion.transform.GetChild(1).GetComponent<Text>();
        descripcion.SetActive(false);
        if (!descripcion.GetComponent<Image>().enabled)
        {
            descripcion.GetComponent<Image>().enabled = true;
            tNombre.enabled = true;
            tDescripcion.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RellenarFondo()
    {
        if (transform.parent.GetComponent<Image>() != null)
        {
            transform.parent.GetComponent<Image>().fillCenter = true;
        }

        tCantidad.text = cantidad.ToString();

        if (transform.parent == Inventario.canvas)
        {
            descripcion.SetActive(false);
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descripcion.SetActive(true);
        tNombre.text = baseDAtos.baseDatos[ID].nombre;
        tDescripcion.text = baseDAtos.baseDatos[ID].descripcion;
        descripcion.transform.position = transform.position + desfase;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descripcion.SetActive(false);
    }
}

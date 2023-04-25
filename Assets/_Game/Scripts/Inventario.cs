using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour
{
    public GraphicRaycaster grafica;
    private PointerEventData datos;
    private List<RaycastResult> resultados;
    public Transform canvas;
    public GameObject objetoSeleccionado;


    // Start is called before the first frame update
    void Start()
    {
        datos = new PointerEventData(null);
        resultados = new List<RaycastResult>();
    }

    public IEnumerator Arrastrar()
    {
        yield return new WaitForSeconds(1f);
        if (Input.GetMouseButtonDown(0))
        {
            datos.position = Input.mousePosition;
            grafica.Raycast(datos, resultados);
            if (resultados.Count > 0)
            {
                if (resultados[0].gameObject.GetComponent<Item>())
                {
                    objetoSeleccionado = resultados[0].gameObject;
                    objetoSeleccionado.transform.SetParent(canvas);
                }
            }
        }

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = RastroObjeto(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            datos.position = Input.mousePosition;
            resultados.Clear();
            grafica.Raycast(datos, resultados);
            if (resultados.Count > 0)
            {
                foreach (var resultado in resultados)
                {
                    if (resultado.gameObject.tag == "Ranura")
                    {
                        objetoSeleccionado.transform.SetParent(resultado.gameObject.transform);
                        objetoSeleccionado.transform.localPosition = Vector2.zero;
                    }
                }
            }
            objetoSeleccionado = null;
        }
        resultados.Clear();
    }

    public Vector2 RastroObjeto (Vector2 posicion)
    {
        Vector2 enfoque = Camera.main.ScreenToViewportPoint(posicion);
        Vector2 tamCanvas = canvas.GetComponent<RectTransform>().sizeDelta;

        return (new Vector2(enfoque.x * tamCanvas.x, enfoque.y * tamCanvas.y) - (tamCanvas/2));
    }

}

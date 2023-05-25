using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour
{

    [System.Serializable]
    public struct ObjetoInvID
    {
        public int id;
        public int cantidad;

        public ObjetoInvID(int id, int cantidad)
        {
            this.id = id;
            this.cantidad = cantidad;
        }

    }

    [SerializeField]
    BaseDatos bDatos;

    [Header("Sontener y Soltar")]
    public GraphicRaycaster grafica;
    private PointerEventData datos;
    private List<RaycastResult> resultados;
    public Transform padreAnt;
    public static Transform canvas;
    public GameObject objetoSeleccionado;

    [Header("Prebas y Objetos")]
    public static GameObject descripcion;
    public OpcionEliminar eliminar;
    public int osc;
    public int osid;

    public Transform contenido;
    public Item item;
    public List<ObjetoInvID> inventario = new List<ObjetoInvID>();

    public Vector3 posOriginal;

    private ControladorSonidos controlSonido;

    // Start is called before the first frame update
    void Start()
    {
        controlSonido = FindObjectOfType<ControladorSonidos>();

        posOriginal = transform.parent.position;

        ActualizarInventario();

        datos = new PointerEventData(null);
        resultados = new List<RaycastResult>();

        descripcion = GameObject.Find("descripcion");

        eliminar.gameObject.SetActive(false);

        canvas = transform.parent.transform;

    }

    private void Update()
    {
        Arrastrar();        
    }

    public void Arrastrar()
    {

        if(Input.GetMouseButtonDown(1))
        {
            datos.position = Input.mousePosition;
            grafica.Raycast(datos, resultados);
            if (resultados.Count > 0)
            {
                if (resultados[0].gameObject.GetComponent<Item>())
                {
                    objetoSeleccionado = resultados[0].gameObject;
                    osc = objetoSeleccionado.GetComponent<Item>().cantidad;
                    osid = objetoSeleccionado.GetComponent<Item>().ID;
                    padreAnt = objetoSeleccionado.transform.parent.transform;
                    padreAnt.GetComponent<Image>().fillCenter = false;
                    objetoSeleccionado.transform.SetParent(canvas);
                }
            }
        }

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = RastroObjeto(Input.mousePosition);
        }

        if (objetoSeleccionado != null)
        {
            if (Input.GetMouseButtonUp(1))
            {
                datos.position = Input.mousePosition;
                resultados.Clear();
                grafica.Raycast(datos, resultados);

                objetoSeleccionado.transform.SetParent(padreAnt);

                if (resultados.Count > 0)
                {
                    foreach (var resultado in resultados)
                    {
                        if (resultado.gameObject == objetoSeleccionado) continue;
                        if (resultado.gameObject.CompareTag("Ranura"))
                        {
                            if (resultado.gameObject.GetComponentInChildren<Item>() == null)
                            {
                                objetoSeleccionado.transform.SetParent(resultado.gameObject.transform);
                            }
                        }
                        if (resultado.gameObject.CompareTag("Item"))
                        {
                            if (resultado.gameObject.GetComponentInChildren<Item>().ID == objetoSeleccionado.GetComponent<Item>().ID)
                            {
                                resultado.gameObject.GetComponentInChildren<Item>().cantidad += objetoSeleccionado.GetComponent<Item>().cantidad;
                                Destroy(objetoSeleccionado.gameObject);
                            }
                            else
                            {
                                objetoSeleccionado.transform.SetParent(resultado.gameObject.transform.parent);
                                resultado.gameObject.transform.SetParent(padreAnt);
                                resultado.gameObject.transform.localPosition = Vector3.zero;
                            }
                        }
                        if (resultado.gameObject.CompareTag("Eliminar"))
                        {
                            if (objetoSeleccionado.gameObject.GetComponent<Item>().cantidad >= 2)
                            {
                                eliminar.gameObject.SetActive(true);
                            }
                            else
                            {
                                eliminar.gameObject.SetActive(false);
                                EliminarItem(objetoSeleccionado.gameObject.GetComponent<Item>().ID, objetoSeleccionado.gameObject.GetComponent<Item>().cantidad);
                            }
                        }
                    }
                }
                objetoSeleccionado.transform.localPosition = Vector3.zero;
                objetoSeleccionado = null;
            }            
        }
        resultados.Clear();
    }

    public void AgregarItem(int id, int cantidad)
    {
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].id == id && bDatos.baseDatos[id].acumulable)
            {
                inventario[i] = new ObjetoInvID(inventario[i].id, inventario[i].cantidad + cantidad);
                ActualizarInventario();
                return;
            }
        }
        if (!bDatos.baseDatos[id].acumulable)
        {
            inventario.Add(new ObjetoInvID(id, 1));
        }
        else
        {
            inventario.Add(new ObjetoInvID(id, cantidad));
        }

        ActualizarInventario();

    }
    public void EliminarItem(int id, int cantidad)
    {
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].id == id)
            {
                inventario[i] = new ObjetoInvID(inventario[i].id, inventario[i].cantidad - cantidad);
                if (inventario[i].cantidad <= 0)
                {
                    inventario.Remove(inventario[i]);
                    ActualizarInventario();
                    break;
                }
            }
            ActualizarInventario();
        }
    }

    public Vector2 RastroObjeto(Vector2 posicionPantalla)
    {
        Vector2 enfoque = Camera.main.ScreenToViewportPoint(posicionPantalla);
        Vector2 tamCanvas = canvas.GetComponent<RectTransform>().sizeDelta;

        return (new Vector2(enfoque.x * tamCanvas.x, enfoque.y * tamCanvas.y) - (tamCanvas/2));
    }

    List<Item> pool = new List<Item>();

    public void ActualizarInventario()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (i < inventario.Count)
            {
                ObjetoInvID o = inventario[i];
                pool[i].ID = o.id;
                pool[i].GetComponent<Image>().sprite = bDatos.baseDatos[o.id].imagen;
                pool[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
                pool[i].cantidad = o.cantidad;
                pool[i].Boton.onClick.RemoveAllListeners();
                pool[i].Boton.onClick.AddListener(() => gameObject.SendMessage(bDatos.baseDatos[o.id].vacio, SendMessageOptions.DontRequireReceiver));
                pool[i].gameObject.SetActive(true);
            }
            else
	        {
                pool[i].gameObject.SetActive(false);
                pool[i].descripcion.SetActive(false);
                pool[i].gameObject.transform.parent.GetComponent<Image>().fillCenter = false;
	        }
    
        }
        if (inventario.Count > pool.Count)
        {
            for (int i = pool.Count; i < inventario.Count; i++)
            {
                for (int j = 0; j < inventario.Count; j++)
                {
                    Item objeto = Instantiate(item, contenido.GetChild(j));

                    pool.Add(objeto);
                    objeto.transform.position = Vector3.zero;
                    objeto.transform.localScale = Vector3.one;
                    if (contenido.GetChild(j).childCount >= 2)
                    {
                        for (int s = 0; s < contenido.childCount; s++)
                        {
                            if (contenido.GetChild(s).childCount == 0)
                            {
                                objeto.transform.SetParent(contenido.GetChild(s));
                                goto continuacion;
                            }
                        }
                    }
                }
                continuacion:


                ObjetoInvID o = inventario[i];
                pool[i].ID = o.id;
                pool[i].GetComponent<Image>().sprite = bDatos.baseDatos[o.id].imagen;
                pool[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
                pool[i].cantidad = o.cantidad;
                pool[i].Boton.onClick.RemoveAllListeners();
                pool[i].Boton.onClick.AddListener(() => gameObject.SendMessage(bDatos.baseDatos[o.id].vacio, SendMessageOptions.DontRequireReceiver));
                pool[i].gameObject.SetActive(true);
            }
        }
    }

    void CasetUno()
    {
        controlSonido.EscogerAudio(1, TiposSonidos.Grabaciones);
    }
    void CasetDos()
    {
        controlSonido.EscogerAudio(2, TiposSonidos.Grabaciones);
    }
    void CasetTres()
    {
        controlSonido.EscogerAudio(3, TiposSonidos.Grabaciones);
    }
    void CasetCuatro()
    {
        controlSonido.EscogerAudio(4, TiposSonidos.Grabaciones);
    }
}

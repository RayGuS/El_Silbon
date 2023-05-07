using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ItemMundo : MonoBehaviour
{

    public int cantidad;
    public int ID;
    public Inventario inv;
    public bool acumulable;

    public bool isColliding;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isColliding && Input.GetKeyDown(KeyCode.J))
        {
            inv.AgregarItem(ID, cantidad);
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

}

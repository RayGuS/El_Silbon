using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBattery : MonoBehaviour
{
    public GameObject dropPlane;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Battery")
        {
            Destroy(collision.gameObject);
        }
    }
}
         
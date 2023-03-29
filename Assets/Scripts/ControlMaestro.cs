using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMaestro : MonoBehaviour
{

    public float tiempo = 160f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     Contador();      
    }

    public void Contador()
    {
        tiempo += Time.deltaTime;
    }


}

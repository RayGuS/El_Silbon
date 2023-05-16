using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IASombra : MonoBehaviour
{
    public Transform jugador;
    public Animator animSombra;
    public float distanciaAtacar;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        
    }
}

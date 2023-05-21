using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IASombra : MonoBehaviour
{
    public Transform jugador;
    public Animator animSombra;
    public float distanciaAtacar;
    public NavMeshAgent agente;
    public bool viva = true;

    // Start is called before the first frame update
    void Start()
    {
        jugador = PlayerController.singleton.transform;
        agente = GetComponent<NavMeshAgent>();
        distanciaAtacar = distanciaAtacar * distanciaAtacar;
    }
    void FixedUpdate()
    {
        if (!viva)
        {
            return;
        }
        transform.LookAt(jugador);
        if ((jugador.position-transform.position).sqrMagnitude > distanciaAtacar)
        {
            agente.SetDestination(jugador.position);
            animSombra.SetBool("Caminar", true);
            animSombra.SetBool("Atacar", false);
            animSombra.SetBool("Morir", false);
        }
        else
        {
            animSombra.SetBool("Caminar", false);
            animSombra.SetBool("Atacar", true);
            animSombra.SetBool("Morir", false);
        }
    }

    public void Morir()
    {
        viva = false;

        animSombra.SetBool("Caminar", false);
        animSombra.SetBool("Atacar", false);
        animSombra.SetBool("Morir", true);
    }
}

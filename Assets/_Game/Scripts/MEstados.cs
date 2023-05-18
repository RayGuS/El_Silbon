using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MEstados : MonoBehaviour
{

    public Estados estado;
    public float distanciaSeguir;
    public float distanciaAtaque;
    public float distanciaHuir;
    public float distanciaJugador;
    public Transform jugador;
    public NavMeshAgent silbon;
    private float desfase = 240f;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MaquinaEstados());
        StartCoroutine(MovimientoAleatorio());
        anim = GameObject.FindGameObjectWithTag("Silbon").GetComponentInChildren<Animator>();
    }

    public IEnumerator MaquinaEstados()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            switch (estado)
            {
                case Estados.Deambular:
                    EstadoDeambular();
                    break;
                case Estados.Perseguir:
                    EstadoPerseguir();
                    break;
                case Estados.Atacar:
                    EstadoAtacar();
                    break;
                default:
                    break;
            }
        }
    }

    public void CalcularDistancia()
    {
        distanciaJugador = Vector3.Distance(jugador.position, transform.position);
    }

    public void CambiarEstado(Estados n)
    {
        switch (n)
        {
            case Estados.Deambular:
                PosicionarAleatorio();
                StartCoroutine(MovimientoAleatorio());
                break;
            case Estados.Perseguir:
                break;
            case Estados.Atacar:
                break;
            default:
                break;
        }

        estado = n;
    }

    public void EstadoDeambular()
    {

        CalcularDistancia();
        if (distanciaJugador < distanciaSeguir)
        {
            CambiarEstado(Estados.Perseguir);
        }

    }

    public void EstadoPerseguir()
    {

        silbon.SetDestination(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
        anim.SetBool("Deambular", true);

        CalcularDistancia();
        if (distanciaJugador < distanciaAtaque)
        {
            CambiarEstado(Estados.Atacar);
        }
        else if (distanciaJugador > distanciaHuir)
        {
            CambiarEstado(Estados.Deambular);
            
        }
    }

    public void EstadoAtacar()
    {
        Debug.Log("Has Muerto");
        anim.SetBool("Deambular", false);
        anim.SetBool("Ataque", true);
    }

    public IEnumerator MovimientoAleatorio()
    {
        yield return new WaitForSeconds(0.1f);
        while (estado == Estados.Deambular)
        {
            yield return new WaitForSeconds(3f);
            PosicionarAleatorio();
            anim.SetBool("Deambular", true);
        } 
    }

    public void PosicionarAleatorio()
    {
        silbon.SetDestination(new Vector3(Random.Range(jugador.position.x - desfase, jugador.position.x + desfase), transform.position.y, Random.Range(jugador.position.z - desfase, jugador.position.z + desfase)));
        ReducirRango();
    }

    public void ReducirRango()
    {
        if (desfase > 0)
        {
            desfase = desfase - Time.deltaTime *30;
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaHuir);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaSeguir);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);

    }

}

public enum Estados
{
    Deambular = 0,
    Perseguir = 1,
    Atacar = 2,
}

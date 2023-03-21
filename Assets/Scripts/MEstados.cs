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



    private Vector3 movimientoAletorio = new Vector3(0, 0, 0);
    private float randomX;
    private float randomZ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MaquinaEstados());
        StartCoroutine(MovimientoAleatorio());
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
        estado = n;
    }

    public void EstadoDeambular()
    {

        movimientoAletorio = new Vector3(randomX, transform.position.y, randomZ);

        silbon.SetDestination(movimientoAletorio);

        if (transform.position == movimientoAletorio)
        {
            StartCoroutine(MovimientoAleatorio());
        }

        CalcularDistancia();
        if (distanciaJugador < distanciaSeguir)
        {
            CambiarEstado(Estados.Perseguir);
        }
    }

    public void EstadoPerseguir()
    {

        movimientoAletorio = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);

        silbon.SetDestination(movimientoAletorio);

        CalcularDistancia();
        if (distanciaJugador < distanciaAtaque)
        {
            CambiarEstado(Estados.Atacar);
        }
        else if (distanciaJugador > distanciaHuir)
        {
            CambiarEstado(Estados.Deambular);
            StartCoroutine(MovimientoAleatorio());
        }
    }

    public void EstadoAtacar()
    {
        Debug.Log("Has Muerto");
    }

    public IEnumerator MovimientoAleatorio()
    {
        yield return new WaitForSeconds(1f);
         randomX = Random.Range(-15, 15);
         randomZ = Random.Range(-15, 15);
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

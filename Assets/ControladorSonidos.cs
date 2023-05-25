using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonidos : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;

    public AudioSource controlSonidosAmbiente;
    public AudioSource controlSonidosFx;
    public AudioSource controlSonidosGrabaciones;
    public AudioSource controlSonidosSilbon;

    public void Awake()
    {

    }

    public void EscogerAudio(int pista, TiposSonidos ts)
    {
        FuenteAudio(ts).clip = audios[pista];
        FuenteAudio(ts).Play();
    }

    public AudioSource FuenteAudio(TiposSonidos ts)
    {
        switch (ts)
        {
            case TiposSonidos.Ambiente:
                return controlSonidosAmbiente;
            case TiposSonidos.Fx:
                return controlSonidosFx;
            case TiposSonidos.Grabaciones:
                return controlSonidosGrabaciones;
            case TiposSonidos.Silbon:
                return controlSonidosSilbon;
            default:
                return controlSonidosAmbiente;
        }
    }

}

public enum TiposSonidos
{
    Ambiente = 0,
    Fx = 1,
    Grabaciones = 2,
    Silbon = 3
}
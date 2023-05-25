using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonidos : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;

    public AudioSource controlSonidos;

    public void Awake()
    {
        controlSonidos = GetComponent<AudioSource>();
    }

    public void EscogerAudio(int pista, float volumen)
    {
        controlSonidos.PlayOneShot(audios[pista], volumen);
    }
}

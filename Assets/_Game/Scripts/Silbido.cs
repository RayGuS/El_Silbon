using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Silbido : MonoBehaviour
{

    public Vector2 tiempo;

    public AudioMixer controlMixer;

    private ControladorSonidos controlSonido;
    private MEstados controlEstados;

    public void SetVolume (float Volumen)
    {
        controlMixer.SetFloat("Volumen", Volumen);
    }

    // Start is called before the first frame update
    void Start()
    {
        controlSonido = FindObjectOfType<ControladorSonidos>();
        controlEstados = FindObjectOfType<MEstados>();
        StartCoroutine(EsperarSilbido());
    }

    public void Silbar()
    {
        controlEstados.CalcularDistancia();
        if (controlEstados.distanciaJugador > 30)
        {
            SetVolume(10);
            controlSonido.EscogerAudio(10, TiposSonidos.Silbon);
        }
        else if (controlEstados.distanciaJugador > 15 && controlEstados.distanciaJugador < 30)
        {
            SetVolume(-20);
            controlSonido.EscogerAudio(10, TiposSonidos.Silbon);
        }
        else
        {
            SetVolume(-40);
            controlSonido.EscogerAudio(10, TiposSonidos.Silbon);
        }
    }

    IEnumerator EsperarSilbido()
    {
        float tiempoEspera = Random.Range(tiempo.x, tiempo.y);
        yield return new WaitForSeconds(tiempoEspera);
        Silbar();
        StartCoroutine(EsperarSilbido());
    }

}

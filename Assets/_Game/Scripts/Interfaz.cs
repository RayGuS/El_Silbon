using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Interfaz : MonoBehaviour
{
    //public GameObject victoria;
    //public GameObject gameOver;
    public GameObject configuracion;
    public GameObject creditos;
    public GameObject inicio;
    public GameObject salir;

    //public BarraVida vida;

    public void PlayGame()
    {
        SceneManager.LoadScene("Natalia");
    }
    public void Configuracion()
    {
        configuracion.SetActive(true);
        inicio.SetActive(false);
        creditos.SetActive(false);
        salir.SetActive(false);
    }
    public void Creditos()
    {
        creditos.SetActive(true);
        inicio.SetActive(false);
        configuracion.SetActive(false);
        salir.SetActive(false);
    }
    public void Salir()
    {
        salir.SetActive(true);
        creditos.SetActive(false);
        inicio.SetActive(false);
        configuracion.SetActive(false);
    }

    public void Volver()
    {
        inicio.SetActive(true);
        configuracion.SetActive(false);
        creditos.SetActive(false);
        salir.SetActive(false);
    }

    public void Si()
    {
        Application.Quit();
    }

    /*public void Fin()
    {
        if (vida.defeat == false)
        {
            victoria.SetActive(true);
            gameOver.SetActive(false);
        }
        else
        {
            victoria.SetActive(false);
            gameOver.SetActive(true);
        }
    }*/
}

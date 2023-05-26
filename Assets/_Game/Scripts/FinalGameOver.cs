using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGameOver : MonoBehaviour
{
    public GameObject video;
    public GameObject gameOver;

    
    public float cambio;
    void Start()
    {
        video.SetActive(true);
        gameOver.SetActive(false);
    }

    
    void Update()
    {
       // cambio = Mathf.Clamp(cambio, 0, 10);
        cambio -=  Time.deltaTime;

        if (cambio <= 0)
        {
           
            //Debug.LogWarning("cambiooo");
             video.SetActive(false);
             gameOver.SetActive(true);
        }
       
    }
}

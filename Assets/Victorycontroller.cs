using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victorycontroller : MonoBehaviour
{
    public GameObject[] pesados;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (pesados.Length == 0)
            {
                SceneManager.LoadScene("Victory");
            }
    }
}

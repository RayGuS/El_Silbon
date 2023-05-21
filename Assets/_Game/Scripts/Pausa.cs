using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
	public GameObject pausa;

	void Update()
	{
		if (Input.GetKeyDown("p"))
		{
			if (Time.timeScale == 1)
			{    
				Time.timeScale = 0;
				pausa.SetActive(true);
			}
			else if (Time.timeScale == 0)
			{   
				Time.timeScale = 1;
				pausa.SetActive(false);
			}
		}
	}
}

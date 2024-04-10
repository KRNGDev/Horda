using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour

{
    public GameObject panelFinal;
    public GameObject panelVida;
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            panelFinal.SetActive(true);
            panelVida.SetActive(false);
            Time.timeScale = 0;
        }
    }
}

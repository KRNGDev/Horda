using System;
using System.Collections.Generic;
using UnityEngine;

public class Fx : MonoBehaviour
{
    [Header("Efectos Genericos")]
    public GameObject humoCircular;
    public AudioClip alientoPlayer;
    public AudioClip audioEspada;

    [Header("Efectos Player")]
    public AudioClip audioPisada1;
    public AudioClip audioPisada2;
    public AudioClip audioPisada;
    public AudioClip audioCaer;
    public AudioClip audioSaltar;

    [Header("Efectos Enemigo")]
    public AudioClip fuego;
    public GameObject ardiendo;
    public AudioClip hielo;




    public void FxParticulas(String particula)
    {

        switch (particula)
        {

            case "humoCircular":
                GameObject Humo = Instantiate(humoCircular, transform.position, transform.rotation);
                break;

        }

    }

}

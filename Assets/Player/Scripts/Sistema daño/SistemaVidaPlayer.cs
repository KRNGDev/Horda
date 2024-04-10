using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SistemaVidaPlayer : MonoBehaviour
{
    [Header("Datos Personaje")]
    public int vidaMax;
    public float vidaActual;
    public String tagEnemigo;
    public Animator animator;
    private GameObject target;
    public Slider sliderVida;
    public GameObject panelGameOver;
    private bool dado = false;


    void Start()
    {

        vidaActual = vidaMax;
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        sliderVida.maxValue = vidaMax;
        sliderVida.value = vidaActual;
        if (vidaActual <= 0)
        {

            animator.SetBool("muerto", true);
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void QuitarVida(int hit)
    {

        vidaActual -= hit;


    }
    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag(tagEnemigo) && !dado)
        {


            int damage = other.GetComponentInParent<enemigo.Enemigo>().puntosDano;
            QuitarVida(damage);

            animator.SetBool("Dado", true);
            dado = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagEnemigo))
        {
            dado = false;
            animator.SetBool("Dado", false);

        }
    }
    public void QuitarGolpe()
    {
        dado = false;
        animator.SetBool("Dado", false);
    }



}


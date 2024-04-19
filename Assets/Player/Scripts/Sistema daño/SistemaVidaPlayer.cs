using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SistemaVidaPlayer : MonoBehaviour
{
    [Header("Datos Personaje")]
    public bool inmortal=false;
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
        if(!inmortal){
            vidaActual -= hit;
        }

        


    }
    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag(tagEnemigo) && !dado)
        {
            enemigo.Enemigo enemigo = other.GetComponentInParent<enemigo.Enemigo>();
            enemigo.EnemigoKamikace Kamikace = other.GetComponentInParent<enemigo.EnemigoKamikace>();
            if (enemigo != null)
            {
                int damage = enemigo.puntosDano;
                QuitarVida(damage);
                animator.SetBool("Dado", true);
                dado = true;
            }
            if (Kamikace != null)
            {
                int damage = Kamikace.puntosDano;
                QuitarVida(damage);
                animator.SetBool("Dado", true);

                dado = true;
            }


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


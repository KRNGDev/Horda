using System;
using System.Collections;
using System.Collections.Generic;
using Enemigo;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SistemaVidaEnemigo : MonoBehaviour
{
    [Header("Datos Personaje")]
    public int vidaMax;
    public float vidaActual;
    public String tagEnemigo;
    private Animator animator;

    [Header("Datos Personaje")]
    public GameObject humo;
    public bool muerto = false;
    private bool dado = false;
    public Slider sliderVida;
    private enemigo.Enemigo scrpitenemigo;
    private PatrullajeManager patrulla;
    private Fx fx;


    void Start()
    {
        animator = GetComponent<Animator>();
        scrpitenemigo = GetComponent<enemigo.Enemigo>();
        patrulla = GetComponent<PatrullajeManager>();
        fx = GetComponent<Fx>();
        vidaActual = vidaMax;
    }
    void Update()
    {
        sliderVida.maxValue = vidaMax;
        sliderVida.value = vidaActual;
        if (vidaActual <= 0 && !muerto)
        {
            muerto = true;

            animator.SetBool("muerto", true);
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
            int damage = other.GetComponentInParent<Player.Player>().puntosDano;
            QuitarVida(damage);
            animator.SetBool("Dado", true);
            dado = true;
        }
        if (other.gameObject.CompareTag("EspadaFuego") && !dado)
        {
            int damage = other.GetComponentInParent<Player.Player>().damageSkil;
            QuitarVida(damage);
            GameObject fuego = Instantiate(fx.ardiendo, transform.position, transform.rotation);
            fuego.transform.parent = transform;

            if (vidaActual >= 0 && !muerto)
            {
                animator.SetBool("caido", true);
                animator.SetBool("ataca", false);
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
    public void DePie()
    {
        dado = false;

        animator.SetBool("caido", false);

    }

    public void Quieto()
    {
        // MonoBehaviour esto coje todo los script del jugador y los desactiva

        MonoBehaviour[] mb = GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour m in mb)
        {
            m.enabled = false;
        }
    }
    public void EnMovimiento()
    {
        // MonoBehaviour esto coje todo los script del jugador y los desactiva

        MonoBehaviour[] mb = GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour m in mb)
        {
            m.enabled = true;
        }
    }
    public void Destruir()
    {
        GetComponent<DropeoItem>().SoltarObjeto();
        Instantiate(humo, transform.position, transform.rotation);
        Destroy(transform.gameObject);
    }
    public void QuitarGolpe()
    {
        dado = false;
        animator.SetBool("Dado", false);
    }



}



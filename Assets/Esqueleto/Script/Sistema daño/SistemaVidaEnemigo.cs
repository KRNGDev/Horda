using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SistemaVidaEnemigo : MonoBehaviour
{
    [Header("Datos Personaje")]
    public int vidaMax;
    public float vidaActual;
    public String tagEnemigo;
    public Animator animator;

    [Header("Datos Personaje")]
    public GameObject humo;
    public bool muerto = false;
    private bool dado = false;
    public Slider sliderVida;


    void Start()
    {
        vidaActual = vidaMax;
    }
    void Update()
    {
        sliderVida.maxValue = vidaMax;
        sliderVida.value = vidaActual;
        if (vidaActual <= 0.2f && !muerto)
        {

            muerto = true;
            animator.SetBool("muerto", true);
            Invoke("Destruir", 2);

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
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagEnemigo))
        {
            dado = false;

            animator.SetBool("Dado", false);
        }
    }
    public void Destruir()
    {


        GetComponent<DropeoItem>().SoltarObjeto();
        Instantiate(humo, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }
    public void QuitarGolpe()
    {
        dado = false;
        animator.SetBool("Dado", false);
    }



}



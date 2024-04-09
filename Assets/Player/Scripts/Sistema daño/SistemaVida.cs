using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace Player
{
    public class SistemaVida : MonoBehaviour
    {
        [Header("Datos Personaje")]
        public int vidaMax;
        public float vidaActual;
        public String tagEnemigo;
        public Animator animator;
        private GameObject target;
        public Slider sliderVida;


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
            }
        }
        public void QuitarVida(int hit)
        {

            vidaActual -= hit;


        }
        void OnTriggerEnter(Collider other)
        {
            int damage = target.GetComponent<Player>().puntosDano;

            if (other.gameObject.CompareTag(tagEnemigo))
            {

                QuitarVida(damage);

                animator.SetBool("Dado", true);
            }

        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(tagEnemigo))
            {

                animator.SetBool("Dado", false);

            }
        }


    }
}

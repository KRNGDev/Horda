using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Enemigo
{
    public class SistemaVida : MonoBehaviour
    {
        [Header("Datos Personaje")]
        public int vidaMax;
        public float vidaActual;
        public String tagEnemigo;
        public Animator animator;


        void Start()
        {
            vidaActual = vidaMax;
        }
        void Update()
        {
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
            if (other.gameObject.CompareTag(tagEnemigo))
            {


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

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace NpcEnemigo
{
    public class SistemaVida : MonoBehaviour
    {
        [Header("Datos Personaje")]
        public int vidaMax;
        public float vidaActual;
        public String tagEnemigo;
        public Animator animator;

        [Header("Datos Personaje")]
        public GameObject humo;
        private bool muerto = false;

        void Start()
        {
            vidaActual = vidaMax;
        }
        void Update()
        {
            if (vidaActual <= 0 && !muerto)
            {

                muerto = true;
                animator.SetBool("muerto", true);
                Invoke("Destruir", 5);

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
        public void Destruir()
        {

            Instantiate(humo, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }


    }
}

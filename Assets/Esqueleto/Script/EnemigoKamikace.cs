using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
namespace enemigo
{
    public class EnemigoKamikace : MonoBehaviour
    {

        [Header("Datos Enemigo")]
        public int puntosDano;

        public float velMovimiento = 5.0f;
        public int distanciaAtaque;

        [Header("Estados Enemigo")]
        public bool atacando = false;
        public bool defendiendo = false;
        public bool estaEnSuelo = true;

        [Header("GameObject Player")]
        public Animator animator;

        private GameObject target;
        private bool muerto = false;



        // Start is called before the first frame update
        void Start()
        {

            animator = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player");

        }

        // Update is called once per frame
        void Update()
        {
            muerto = GetComponent<SistemaVidaEnemigo>().muerto;
            if (!muerto)
            {
                if (!atacando)
                {
                    animator.SetFloat("Y", 1);
                    transform.Translate(Vector3.forward * velMovimiento * Time.deltaTime);
                    transform.LookAt(target.transform.position);
                }

                if (Vector3.Distance(transform.position, target.transform.position) < 2f)
                {
                    atacando = true;


                    animator.SetBool("ataca", true);

                    //transform.LookAt(target.transform);
                }
                else
                {
                    atacando = false;
                    animator.SetBool("ataca", false);
                }

            }

        }


    }
}

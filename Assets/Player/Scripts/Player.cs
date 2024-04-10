using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class Player : MonoBehaviour
    {

        [Header("Datos Player")]
        public int puntosDano;
        public float fuerzaSalto = 10.0f;
        public float velRotate = 200.0f;
        public float velMovimiento = 5.0f;
        private float x, y;

        [Header("Estados Player")]
        public bool atacando = false;
        public bool defendiendo = false;
        private bool segundoAtaque = false;
        public bool estaEnSuelo = true;

        [Header("GameObject Player")]
        public Animator animator;
        private Rigidbody rbPlayer;



        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;

            rbPlayer = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {


            //Ataque

            if (Input.GetButtonDown("Fire1"))
            {

                animator.SetBool("Ataca", true);
                atacando = true;


            }
            if (Input.GetButtonUp("Fire1"))
            {
                segundoAtaque = false;
                animator.SetBool("Ataca", false);
                animator.SetBool("AtaqueFuerte", false);

                atacando = false;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                defendiendo = true;

                animator.SetBool("Defendiendo", true);
            }
            if (Input.GetButtonUp("Fire2"))
            {
                animator.SetBool("Defendiendo", false);
                defendiendo = false;
            }

            //Movimiento Player
            if (atacando == false && defendiendo == false)
            {
                x = Input.GetAxis("Horizontal");
                y = Input.GetAxis("Vertical");

                transform.Rotate(0, x * Time.deltaTime * velRotate, 0);
                transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);

                animator.SetFloat("X", x);
                animator.SetFloat("Y", y);
                if (Input.GetButtonDown("Jump") && estaEnSuelo)
                {

                    rbPlayer.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                    animator.SetBool("Saltando", true);
                    animator.SetBool("EstaEnSuelo", false);
                    estaEnSuelo = false;


                }
            }

        }
        public void OnAtaqueAnimationEvent()

        {
            if (segundoAtaque == true)
            {
                animator.SetBool("AtaqueFuerte", true);
            }
            segundoAtaque = true;


        }
        private void OnTriggerEnter(Collider other)
        {
            animator.SetBool("EstaEnSuelo", true);
            animator.SetBool("Saltando", false);
            estaEnSuelo = true;

        }
        private void OnTriggerExit(Collider other)
        {
            animator.SetBool("EstaEnSuelo", false);

            estaEnSuelo = false;
        }
        private void OnTriggerStay(Collider other)
        {

            animator.SetBool("EstaEnSuelo", true);
            animator.SetBool("Saltando", false);
            estaEnSuelo = true;
        }



    }
}
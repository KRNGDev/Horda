using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Enemigo
{
    public class Enemigo : MonoBehaviour
    {

        [Header("Datos Enemigo")]
        public int puntosDano;
        public float fuerzaSalto = 10.0f;
        public float velRotate = 200.0f;
        public float velMovimiento = 5.0f;
        private float x, y;
        public int distanciaAtaque;

        [Header("Estados Enemigo")]
        public bool atacando = false;
        public bool defendiendo = false;
        public bool estaEnSuelo = true;

        [Header("GameObject Player")]
        public Animator animator;
        private Rigidbody rbPlayer;
        public Transform TransformTarget;
        private GameObject target;
        private Player.Player targetPlayer;
        private int damage;
        // Start is called before the first frame update
        void Start()
        {
            rbPlayer = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player");
            targetPlayer = target.GetComponent<Player.Player>();
            TransformTarget = GameObject.FindGameObjectWithTag("Player").transform;

        }

        // Update is called once per frame
        void Update()
        {
            if (!target || Vector3.Distance(transform.position, target.transform.position) < 5)
            {

                GetComponent<NavMeshAgent>().destination = TransformTarget.position;
                if (Vector3.Distance(transform.position, target.transform.position) < 2.5f)
                {

                    animator.SetBool("ataca", true);
                }
                else
                {
                    animator.SetBool("ataca", false);
                }
            }
            //
        }
        /*void OnTriggerEnter(Collider other)
        {
            damage = targetPlayer.puntosDano;
            if (other.CompareTag("Espada"))
            {

                GetComponent<NpcEnemigo.SistemaVida>().QuitarVida(damage);
            }
        }*/

    }
}

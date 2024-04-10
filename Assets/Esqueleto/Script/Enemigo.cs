using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
namespace enemigo
{
    public class Enemigo : MonoBehaviour
    {

        [Header("Datos Enemigo")]
        public int puntosDano;
        public float fuerzaSalto = 10.0f;
        public float velRotate = 200.0f;
        public float velMovimiento = 5.0f;
        public int distanciaAtaque;

        [Header("Estados Enemigo")]
        public bool atacando = false;
        public bool defendiendo = false;
        public bool estaEnSuelo = true;

        [Header("GameObject Player")]
        public Animator animator;

        public Transform TransformTarget;
        private GameObject target;
        private bool muerto;
        public Camera camara;


        // Start is called before the first frame update
        void Start()
        {
            ConstraintSource cs = new ConstraintSource();
            cs.weight = 1;
            cs.sourceTransform = Camera.main.transform;
            GetComponentInChildren<LookAtConstraint>().AddSource(cs);
            animator = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player");
            TransformTarget = GameObject.FindGameObjectWithTag("Player").transform;

        }

        // Update is called once per frame
        void Update()
        {
            muerto = GetComponent<SistemaVidaEnemigo>().muerto;
            if (!muerto)
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
            }

        }


    }
}

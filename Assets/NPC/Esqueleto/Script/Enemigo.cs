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
        public float tiempoCongelado = 1;
        public int distanciaAtaque;
        public GameObject rayos;

        [Header("Estados Enemigo")]
        public bool atacando = false;
        public bool defendiendo = false;
        public bool estaEnSuelo = true;

        [Header("GameObject Player")]
        private Animator animator;

        private Transform TransformTarget;
        private GameObject target;
        private bool muerto;
        public bool congelado = false;


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
                if (Vector3.Distance(transform.position, target.transform.position) < 8)
                {
                    

                    GetComponent<NavMeshAgent>().destination = target.transform.position;
                    if (Vector3.Distance(transform.position, target.transform.position) < 2.5f)
                    {
                        transform.LookAt(transform);
                        animator.SetBool("ataca", true);
                    }
                    else
                    {
                        animator.SetBool("ataca", false);
                    }
                }
            }
            if (congelado)
            {
                Animacion();
            }

        }

        public void Animacion()
        {congelado = false;
            //GetComponent<Animator>().enabled = false;
            GetComponent<Animator>().SetBool("caido", true);
            GameObject aturdido=Instantiate(rayos,transform.position,transform.rotation);
            aturdido.transform.parent = transform;
            Invoke("Activar", tiempoCongelado);
        }
        public void Activar()
        {
           // GetComponent<Animator>().enabled = true;
           GetComponent<Animator>().SetBool("caido", false);

            
        }

    }
}

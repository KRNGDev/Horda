using System.Collections;
using System.Collections.Generic;
using Enemigo;
using UnityEngine;

public class BombaConLayer : MonoBehaviour
{
    [Header("Radio de acción de la explosión en metros")]
    public float radio;
    public float fuerzaHorizontal;
    public float fuerzaVertical;

    [Header("Segundos de espera antes de la explosión")]
    public int temporizador;

    public LayerMask layerMask;
    private enemigo.Enemigo scrpitenemigo;
    private PatrullajeManager patrulla;

    void Start()
    {
        Invoke("Explotar", temporizador);
    }

    void Explotar()
    {
        //Obtiene los colliders afectados por la explosión
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radio, layerMask);
        //Recorre los colliders y a aquellos que tienen RigidBody les aplica una explosión de fuerza
        foreach (var collider in hitColliders)

        {
            MonoBehaviour[] mb = collider.GetComponentsInChildren<MonoBehaviour>();
            foreach (MonoBehaviour m in mb)
            {
                print("Lo hace");
                m.enabled = false;
            }

            if (collider.GetComponent<Rigidbody>() != null)
            {


                collider.GetComponent<Rigidbody>().AddExplosionForce(
                    fuerzaHorizontal,
                    transform.position,
                    radio,
                    fuerzaVertical);

            }
            if (collider.GetComponent<Animator>() != null)
            {
                collider.GetComponent<Animator>().enabled = false;
            }
        }

    }


}

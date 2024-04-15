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
            if (collider.GetComponent<Rigidbody>() != null)
            {
                scrpitenemigo = GetComponentInChildren<enemigo.Enemigo>();
                patrulla = GetComponentInChildren<PatrullajeManager>();
                // Quieto();
                DesactivarComponentesHijos(collider.transform);

                collider.GetComponent<Rigidbody>().AddExplosionForce(
                    fuerzaHorizontal,
                    transform.position,
                    radio,
                    fuerzaVertical);

            }
        }
        Invoke("ActivarComponentesHijos", 1f);
    }
    private void DesactivarComponentesHijos(Transform parent)
    {
        // Recorre los componentes en los hijos y los desactiva
        foreach (Transform child in parent)
        {
            // Desactiva el componente si es diferente de null
            if (child.gameObject.TryGetComponent(out MonoBehaviour componente))
            {
                componente.enabled = false;
            }

            // Llama a esta función recursivamente para desactivar los componentes en los hijos de este hijo
            DesactivarComponentesHijos(child);
        }
    }
    private void ActivarComponentesHijos()
    {
        // Reactiva los componentes en los hijos del objeto
        ActivarComponentesHijos(transform);
    }

    private void ActivarComponentesHijos(Transform parent)
    {
        // Recorre los componentes en los hijos y los activa
        foreach (Transform child in parent)
        {
            // Activa el componente si es diferente de null
            if (child.gameObject.TryGetComponent(out MonoBehaviour componente))
            {
                componente.enabled = true;
            }

            // Llama a esta función recursivamente para activar los componentes en los hijos de este hijo
            ActivarComponentesHijos(child);
        }
    }

    public void Quieto()
    {
        Invoke("Activar", 1);
        print("quieto");
        if (patrulla != null)
        {
            patrulla.enabled = false;
        }
        if (scrpitenemigo != null)
        {
            scrpitenemigo.enabled = false;
        }


    }
    public void Activar()
    {
        print("Activo");
        if (patrulla != null)
        {
            patrulla.enabled = false;
        }
        if (scrpitenemigo != null)
        {
            scrpitenemigo.enabled = false;
        }
    }
}

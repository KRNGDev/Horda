using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirTiempo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destruir();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Destruir()
    {
        Destroy(gameObject, 1.5f);
    }
}

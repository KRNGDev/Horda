﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject pickupEffect;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Espada"))
        {
            Pickup();
        }
    }

    void Pickup()
    {


        Instantiate(pickupEffect, transform.position, transform.rotation);


        Destroy(gameObject);
    }
}

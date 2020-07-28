﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;

    public float force = 700f;

    public GameObject explodeEf;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;
    }

    
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
        

    }

    void Explode()
    {
        Debug.Log("Boom");

        Instantiate(explodeEf, transform.position, transform.rotation);

        Collider[] collisers=Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nerbyObject in collisers)
        {
            Rigidbody rb= nerbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

        }


        Destroy(gameObject);
        
    }
}

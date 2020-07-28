using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wybuch : MonoBehaviour
{
    public float delay = 3f;

    float countdown;
    public float radius = 5f;
    public float force = 700f;

    public GameObject explosionEffect;

    bool hasExploated = false;
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploated)
        {
            Explode();
            hasExploated = true;
        }
    }
    void Explode()
    {



        Collider[] colliders= Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nerbyObject in colliders)
        {
            Rigidbody rb = nerbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{

    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public GameObject fpsCam;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            throwGrenade();
        }
        
          
        

    }

    void throwGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}

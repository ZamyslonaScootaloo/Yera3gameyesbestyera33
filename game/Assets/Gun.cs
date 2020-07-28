
using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce=30f;

    public int maxAmmo = 10;
    //public bool scoped = false;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading=false;

    public Camera fpsCam;
    //public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    //public GameObject weapon;

    private float nextTimeToFire = 0f;

    void Start()
    {
        
          currentAmmo = maxAmmo;
        
    }

    
    void Update()
    {

        if (isReloading)
            return;


         if (currentAmmo <= 0)
            {
                StartCoroutine(Relaod());
                return;
            }

        if (Input.GetButton("Fire1")&& Time.time>=nextTimeToFire)
        {
           
            
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
/*
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (scoped == false)
            {
                scoped = true;
                Scope();
            }
            if (scoped == true)
            {
                scoped = false;
                Scope();
            }                                               
        }
*/
    }
    IEnumerator Relaod()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
        
    }

    void Shoot()
    {
        //muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);


            Target target = hit.transform.GetComponent<Target>();
            if ( target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }
    }
    /*
    public void Scope()
    {
        if (scoped == true)
        {
            weapon.transform.position = new Vector3(0, -0.516f, 0.751f);
        }
        if (scoped == false)
        {
            weapon.transform.position = new Vector3(0.442f, -0.666f, 0.887f);
        }
    }
    */
}

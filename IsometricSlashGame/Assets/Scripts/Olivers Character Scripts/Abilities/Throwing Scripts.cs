using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ThrowingScripts : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse1;
    public float throwForce;
    public float throwUpwardForce;

    [Header("Grenade Options")]
    public int explosionDamage = 0;
    public float explosionTimer = 0;
    public float explosionRadius = 0;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }

        /*if (explosionTimer <)
        {
            Debug.Log("Explodera");
        } else
        {
            explosionTimer -= Time.deltaTime;
        }*/

    }

    public void Throw()
    {
        readyToThrow = false;

        //Instantiate object to throw
        GameObject projectile = (GameObject)Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        //Get the rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>(); 

        //add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        //ActivateGrenade();
        totalThrows--;
        StartCoroutine(GrenadeTimer(projectile));

        //Implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
    /*private void ActivateGrenade()
    {
        
    }*/

    IEnumerator GrenadeTimer(GameObject projectile)
    {
        yield return new WaitForSeconds(explosionTimer);
        Debug.Log("Explodera");
        Collider[] hits = Physics.OverlapSphere(projectile.transform.position, explosionRadius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.GetComponent<EnemyHealth>().TakeDamage(explosionDamage);
            }
        }
        Destroy(projectile);

    }

}

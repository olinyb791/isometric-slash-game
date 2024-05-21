using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public WeaponController wc;
    public GameObject HitParticle;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && wc.IsAttacking && wc.HasAttacked == false)
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
            wc.SwordHit(other, 10);
            //Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetector : MonoBehaviour
{
    public EnemyCombat ec;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerCharacter" && ec.enemyIsAttacking && !ec.enemyHasAttacked)
        {
            //other.GetComponent<Animator>().SetTrigger("Hit");
            ec.EnemyAttackHit(other, 10);
            //Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }

}

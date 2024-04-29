using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public EnemyCombat enemyCombat;
    // distansen då fienden börjar jaga en under sin attack om spelaren springer för långt iväg
    private float beginChase = 4f;
    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            Debug.Log(enemyCombat.enemyIsAttacking);
            if (!enemyCombat.enemyIsAttacking || distance > beginChase)
            {
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    //Face the target
                    FaceTarget();
                    //Attack the target
                    enemyCombat.EnemyAttack();

                }
            }
        }
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}

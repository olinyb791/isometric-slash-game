using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject Sword;
    [SerializeField] private float AttackCooldown = 3.0f;
    [SerializeField] private float AttackDuration = 2.0f;
    public bool enemyIsAttacking = false;
    public bool enemyHasAttacked = false;
    public bool enemyCanAttack = true;

    public void EnemyAttack()
    {
        StartCoroutine(EnemyAttackCooldown());
        enemyIsAttacking = true;
        enemyCanAttack = false;
        Debug.Log("Attackera");
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("EnemyAttack");
    }

    public void EnemyAttackHit(Collider other, int dmg)
    {
        Debug.Log("Träffade något" + other.tag);
        if (other.tag == "PlayerCharacter" && enemyIsAttacking && !enemyHasAttacked)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(dmg);
            enemyHasAttacked = true;
        }
    }

    IEnumerator EnemyAttackCooldown()
    {
        StartCoroutine (EnemyAttackDuration());
        yield return new WaitForSeconds(AttackCooldown);
        enemyHasAttacked = false;
        enemyCanAttack = true;
    }

    IEnumerator EnemyAttackDuration()
    {
        yield return new WaitForSeconds(AttackDuration);
        enemyIsAttacking = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

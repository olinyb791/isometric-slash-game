using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 0.6f;
    public bool IsAttacking = false;
    public bool HasAttacked = false;

    public void OnSlash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }
    }

    void Update()
    {
 
    }

    public void SwordAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    } 

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        HasAttacked = false;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.7f);
        IsAttacking = false;
    }


}

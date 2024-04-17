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
    public bool inCombatState = false;
    public Camera mainCamera;
    public Transform player;
    [SerializeField] private float combatCooldown = 0f;
    private float combatCooldownDuration = 15f;

    public void OnSlash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
            if (inCombatState && !IsAttacking)
            {
                ResetCombatState();
                SwordAttack();
            }

            if (!inCombatState && !IsAttacking)
            {
                EnterCombatState();
                SwordAttack();
            }

        }
    }

    void Update()
    {
        if (inCombatState)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //Hämtar i våran 3D värld där rayen träffar
                Vector3 cursorWorldPosition = hit.point;

                Vector3 direction = cursorWorldPosition - player.position;
                direction.y = 0f;
                player.rotation = Quaternion.LookRotation(direction);
            }

        }

        if (combatCooldown <= 0f) {
            inCombatState = false;
        } else
        {
            combatCooldown -= Time.deltaTime;
        }
    }

    public void SwordAttack()
    {
        IsAttacking = true;
        CanAttack = false;

        Animator anim = Sword.GetComponent<Animator>();

        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    } 

    private void EnterCombatState()
    {
        Debug.Log("Entered combat state");
        inCombatState = true;
        combatCooldown = combatCooldownDuration;
    }

    private void ResetCombatState()
    {
        Debug.Log("Reset combat state");
        combatCooldown = combatCooldownDuration;
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

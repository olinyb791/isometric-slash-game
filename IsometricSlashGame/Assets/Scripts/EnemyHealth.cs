using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public WeaponController wc;
    public GameObject dyingEnemy;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            TakeDamage(20);
        }*/

        if (currentHealth <= 0)
        {
            Animator anim = Enemy.GetComponent<Animator>();
            anim.SetTrigger("Die");
            StartCoroutine(Dying());
            
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon" && wc.IsAttacking && wc.HasAttacked == false)
        {
            Debug.Log("Snälla ta skada");
            TakeDamage(10);
            wc.HasAttacked = true;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);


    }

    IEnumerator Dying()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(dyingEnemy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    /*
    public Animator animator;
    */

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public int heavyAttackDamage = 100;

    public LayerMask enemyLayers;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            HeavyAttack();
        }
    }

    void Attack()
    {
        /*
        play attack animation
        detect if enemies are in range
        damage the enemies
        */

        /*
        animation.SetTrigger("Attack");
        */

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHP>().TakeDamage(attackDamage);
        }
    }

    void HeavyAttack()
    {
        /*
        play attack animation
        detect if enemies are in range
        damage the enemies
        */

        /*
        animation.SetTrigger("Attack");
        */

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHP>().TakeDamage(heavyAttackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float timebtwAttack;
    public float startTimeAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    void Update()
    {
        if(timebtwAttack <= 0)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                
                animator.SetBool("isattacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                print("frie1 up");
                animator.SetBool("isattacking", false);
            }



            timebtwAttack = startTimeAttack;
        }
        else {
            timebtwAttack -= Time.deltaTime;
                }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position,attackRange);
        }

    }
}

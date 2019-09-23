using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    float horizantalMove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool crouch = false;
    bool isCrouching = false;

    //
    private float timebtwAttack;
    public float startTimeAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;


    void FixedUpdate()
    {
        controller.Move(horizantalMove * Time.deltaTime, crouch, jump);
        jump = false;
        //crouch = false;

    }

    void Update()
    {
        horizantalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        animator.SetFloat("speed", Mathf.Abs(horizantalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isjumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("iscrouching", true);
            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("iscrouching", false);
            crouch = false;
        }




        /////
        ///
        //if (timebtwAttack <= 0)
        //{

        if (Input.GetButtonDown("Fire1"))
        {

            animator.SetBool("isattacking", true);
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                print("hitting");
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            print("frie1 up");
            animator.SetBool("isattacking", false);
        }



        timebtwAttack = startTimeAttack;
        //}
        //else
        //{
        //    timebtwAttack -= Time.deltaTime;
        //}



        ////


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void onLanding()
    {
        animator.SetBool("isjumping", false);
    }

    

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    public GameObject bloodEffect;



    void Start()
    {

    }




    void Update()
    {
        // print(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        print("take damg");
        health -= damage;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);

        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour

{
    public pointScript pointScript;
    public audioScript audioScript;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            pointScript.setCount();
            audioScript.playSound();
        }
    }
}

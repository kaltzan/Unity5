using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public audioScript audioScript;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "powerG")
        {
            transform.localScale *= 1.1f;
            Destroy(col.gameObject);
            audioScript.playSound();
            transform.localScale *= 1.1f;
        }
    }
}

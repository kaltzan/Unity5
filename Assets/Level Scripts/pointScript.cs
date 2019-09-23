using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointScript : MonoBehaviour
{
    public int count;
    public Text countText;

    public static pointScript instance;

    void Awake()
    {
        instance = this;
        count = 0;
        setCountText();
    }
    public void setCount()
    {
        count = count + 1;
        countText.text = "x " + count.ToString();
    }

    public void setCountText()
    {
        countText.text = "x " + count.ToString();
    }
}
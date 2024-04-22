using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderTaleText : MonoBehaviour
{
    public float timer;
    public Text text;
    public Color color;
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer > 1)
        {
            color.a -=Time.deltaTime;
        }
        text.color= color;
    }
}

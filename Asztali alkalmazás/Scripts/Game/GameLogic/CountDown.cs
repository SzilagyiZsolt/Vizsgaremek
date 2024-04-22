using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject door;
    public float countDown;
    public float min;
    public Text minutes;
    public Text seconds;

    // Update is called once per frame
    void Update()
    {
        if (countDown>=0.5)
        {
            countDown-=Time.deltaTime;
        }
        else
        {
            door.SetActive(true);
            this.gameObject.SetActive(false);
        }
        double b=System.Math.Round(countDown,0);
        min=Mathf.FloorToInt(countDown/60);
        float sec=Mathf.FloorToInt(countDown%60);
        minutes.text=min.ToString();
        seconds.text=sec.ToString();
    }
}

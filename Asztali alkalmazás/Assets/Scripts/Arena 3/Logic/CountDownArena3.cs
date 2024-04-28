using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownArena3 : MonoBehaviour
{
    public float countDown;
    public float min;
    public Text minutes;
    public Text seconds;
    public GameObject[] enemySpawners;

    // Update is called once per frame
    void Update()
    {
        if (countDown >= 0.5)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        if(min < 2)
        {
            enemySpawners[0].SetActive(false);
        }
        if(min < 1)
        {
            enemySpawners[1].SetActive(false);
        }
        min = Mathf.FloorToInt(countDown / 60);
        float sec = Mathf.FloorToInt(countDown % 60);
        minutes.text = min.ToString();
        seconds.text = sec.ToString();
    }
}

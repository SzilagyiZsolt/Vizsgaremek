using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SlimeDeath : MonoBehaviour
{
    public float timer;
    public SlimeHealth slimeHealth;
    public SlimeXP slimeXP;
    public int counter;
    private void Start()
    {
        slimeHealth = GetComponent<SlimeHealth>();
        slimeXP = GetComponent<SlimeXP>();
    }
    private void Update()
    {
        if (slimeHealth.slimeHealth <= 0)
        {
            counter++;
            if (counter == 10)
            {
                slimeXP.SlimeGiveXP();
                slimeXP.SlimeGiveGold();
            }
            timer+=Time.deltaTime;
            if (timer>1.4)
            {
                Destroy(gameObject);
            }
            slimeHealth.anim.SetBool("Death", true);
            slimeHealth.slimealive = false;
        }
    }
}

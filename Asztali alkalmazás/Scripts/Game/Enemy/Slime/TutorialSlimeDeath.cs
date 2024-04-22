using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TutorialSlimeDeath : MonoBehaviour
{
    public int coin;
    public float timer;
    public SlimeHealth slimeHealth;
    public TutorialSlimeXP tutorialSlimeXP;
    public int counter;
    private void Start()
    {
        slimeHealth = GetComponent<SlimeHealth>();
        tutorialSlimeXP = GetComponent<TutorialSlimeXP>();
    }
    private void Update()
    {
        if (slimeHealth.slimeHealth <= 0)
        {
            counter++;
            if (counter == 10)
            {
                tutorialSlimeXP.SlimeGiveXP();
                tutorialSlimeXP.SlimeGiveGold();
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

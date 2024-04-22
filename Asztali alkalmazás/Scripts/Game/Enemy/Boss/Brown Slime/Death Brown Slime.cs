using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBrownSlime : MonoBehaviour
{
    public float timer;
    public HealthBrownSlime brownSlimeHealth;
    public XPBrownSlime brownSlimeXP;
    private void Start()
    {
        brownSlimeHealth = GetComponent<HealthBrownSlime>();
        brownSlimeXP = GetComponent<XPBrownSlime>();
    }
    private void Update()
    {
        if (brownSlimeHealth.brownSlimeHealth <= 0)
        {
            timer += Time.deltaTime;
            if (timer > 1.4)
            {
                brownSlimeXP.BrownSlimeGiveGold();
                Destroy(gameObject);
            }
            brownSlimeHealth.anim.SetBool("Death", true);
            brownSlimeHealth.brownSlimealive = false;
        }
    }
}

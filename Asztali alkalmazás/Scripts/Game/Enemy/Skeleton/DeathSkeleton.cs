using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DeathSkeleton : MonoBehaviour
{
    public XPSkeleton xpSkeleton;
    public float timer;
    public HealthSkeleton skeletonHealth;
    public int counter;
    private void Start()
    {
        skeletonHealth = GetComponent<HealthSkeleton>();
        xpSkeleton = GetComponent<XPSkeleton>();
    }
    private void Update()
    {
        if (skeletonHealth.skeletonHealth <= 0)
        {
            counter++;
            if (counter == 10)
            {
                xpSkeleton.SkeletonGiveXP();
                xpSkeleton.SkeletonGiveGold();
            }
            timer += Time.deltaTime;
            if (timer > 1.4)
            {
                Destroy(gameObject);
            }
            skeletonHealth.anim.SetBool("Death", true);
            skeletonHealth.skeletonalive = false;
        }
    }
}

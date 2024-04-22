using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSkeletonKing : MonoBehaviour
{
    public float timer;
    public HealthSkeletonKing skeletonKingHealth;
    public XPSkeletonKing xpSkeletonKing;
    private void Start()
    {
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
        xpSkeletonKing = GetComponent<XPSkeletonKing>();
    }
    private void Update()
    {
        if (skeletonKingHealth.skeletonKingHealth <= 0)
        {
            timer += Time.deltaTime;
            if (timer > 1.4)
            {
                xpSkeletonKing.SkeletonKingGiveGold();
                Destroy(gameObject);
            }
            skeletonKingHealth.anim.SetBool("Death", true);
            skeletonKingHealth.skeletonKingalive = false;
        }
    }
}

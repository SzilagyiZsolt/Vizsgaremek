using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSkeleton : MonoBehaviour
{
    public ClassLoader classLoader;
    public CountDown countDown;
    public KnightXP knightXP;
    public ArcherXP archerXP;
    public HealthSkeleton healthSkeleton;
    public DamageSkeleton damageSkeleton;
    public int skeletonXP = 1;
    public int skeletonCoin = 1;
    public int skeletonLevel = 1;
    public float timer;
    public int minutes = 5;
    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject player = GameObject.FindWithTag("Player");
        if (classLoader.isKnight)
        {
            knightXP=player.GetComponent<KnightXP>();
        }
        else
        {
            archerXP=player.GetComponent<ArcherXP>();
        }
        healthSkeleton = GetComponent<HealthSkeleton>();
        damageSkeleton = GetComponent<DamageSkeleton>();
        GameObject count = GameObject.FindWithTag("CountDown");
        countDown = count.GetComponent<CountDown>();
        SkeletonLevelUp();
    }

    public void SkeletonGiveXP()
    {
        if (!healthSkeleton.skeletonalive && classLoader.isKnight)
        {
            knightXP.playerXP+=skeletonXP;
        }
        else if (!healthSkeleton.skeletonalive && !classLoader.isKnight)
        {
            archerXP.playerXP+=skeletonXP;
        }
    }
    public void SkeletonGiveGold()
    {
        if (!healthSkeleton.skeletonalive && classLoader.isKnight)
        {
            knightXP.coinAmount+=skeletonCoin;
            knightXP.coinText.text= knightXP.coinAmount.ToString();
        }
        else if (!healthSkeleton.skeletonalive && !classLoader.isKnight)
        {
            archerXP.coinAmount+=skeletonCoin;
            archerXP.coinText.text= archerXP.coinAmount.ToString();
        }
    }
    public void SkeletonLevelUp()
    {
        while (countDown.min<minutes)
        {
            skeletonLevel++;
            skeletonCoin*=skeletonLevel;
            switch (skeletonLevel)
            {
                case 2:
                    healthSkeleton.skeletonMaxHealth*=2;
                    damageSkeleton.damage *= 1.5f;
                    break;
                case 3:
                    healthSkeleton.skeletonMaxHealth*=2;
                    damageSkeleton.damage *= 2;
                    break;
                case 4:
                    healthSkeleton.skeletonMaxHealth*=2;
                    damageSkeleton.damage *= 2;
                    break;
                case 5:
                    healthSkeleton.skeletonMaxHealth*=1.5f;
                    damageSkeleton.damage *= 2;
                    break;
            }
            minutes--;
        }
    }
}

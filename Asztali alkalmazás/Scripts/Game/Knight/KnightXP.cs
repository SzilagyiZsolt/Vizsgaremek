using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class KnightXP : MonoBehaviour
{
    public SaveManager saveManager;
    public Text LevelText;
    public Text coinText;
    public Slider sliderXP;
    public KnightHealth knightHealth;
    public KnightAttack knightAttack;
    public int playerXP=0;
    public int playermaxXP=1;
    public int playerLevel = 1;
    public int coinAmount;
    private void Start()
    {
        knightAttack = GetComponent<KnightAttack>();
        knightHealth = GetComponent<KnightHealth>();
    }
    void Update()
    {
        coinText.text=coinAmount.ToString();
        sliderXP.maxValue=playermaxXP;
        sliderXP.value=playerXP;
        while (playerXP >= playermaxXP && playerLevel<999)
        {   
            coinAmount+=5;
            playerXP -= playermaxXP;
            playerLevel++;
            playermaxXP++;
            knightHealth.maxHealth*=1.1f;
            knightAttack.damage*=1.1f;
            knightHealth.health=knightHealth.maxHealth;
            LevelText.text=playerLevel.ToString();
            coinText.text=coinAmount.ToString();
        }
    }
}

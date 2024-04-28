using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ArcherXP : MonoBehaviour
{
    public SaveManager saveManager;
    public Text LevelText;
    public Text coinText;
    public Slider sliderXP;
    public ArcherHealth archerHealth;
    public ArcherAttack archerAttack;
    public int playerXP=0;
    public int playermaxXP=1;
    public int playerLevel = 1;
    public int coinAmount;
    private void Start()
    {
        archerAttack = GetComponent<ArcherAttack>();
        archerHealth = GetComponent<ArcherHealth>();
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
            archerHealth.maxHealth*=1.1f;
            archerAttack.damage*=1.2f;
            archerHealth.health=archerHealth.maxHealth;
            LevelText.text=playerLevel.ToString();
            coinText.text=coinAmount.ToString();
        }
    }
}

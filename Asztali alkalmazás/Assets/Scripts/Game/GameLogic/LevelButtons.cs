using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelButtons : MonoBehaviour
{
    public Image arena1Image;
    public Image arena2Image;
    public Button arena2Button;
    public Image arena3Image;
    public Button arena3Button;
    public bool WorldBoss1Killed=false;
    public bool WorldBoss2Killed=false;
    public bool pressedArena1 = false;
    public bool pressedArena2 = false;
    public bool pressedArena3 = false;
    private void Start()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat"))
        {
            WorldBoss1Killed = true;
        }
        if (WorldBoss1Killed)
        {
            arena2Button.interactable = true;
            arena2Image.color = Color.white;
        }
        else
        {
            arena2Button.interactable = false;
            arena2Image.color=Color.red;
        }

        if (File.Exists(Application.dataPath + "/" + $"{DBManager.username}WorldBosses2.dat"))
        {
            WorldBoss2Killed = true;
        }
        if (WorldBoss2Killed)
        {
            arena3Button.interactable = true;
            arena3Image.color = Color.white;
        }
        else
        {
            arena3Button.interactable = false;
            arena3Image.color = Color.red;
        }
    }
    void Update()
    {
        //Level1
        if (pressedArena1)
        {
            arena1Image.fillAmount -= Time.deltaTime;
        }
        if (arena1Image.fillAmount == 0)
        {
            SceneManager.LoadScene("Arena1");
        }

        //Level2
        if (pressedArena2)
        {
            arena2Image.fillAmount -= Time.deltaTime;
        }
        if (arena2Image.fillAmount == 0)
        {
            SceneManager.LoadScene("Arena2");
        }

        //Level3
        if (pressedArena3)
        {
            arena3Image.fillAmount -= Time.deltaTime;
        }
        if (arena3Image.fillAmount == 0)
        {
            SceneManager.LoadScene("Arena3");
        }
    }
    public void LevelLoadingArena1()
    {
        pressedArena1 = true;
    }
    public void LevelLoadingArena2()
    {
        pressedArena2 = true;
    }
    public void LevelLoadingArena3()
    {
        pressedArena3 = true;
    }
}

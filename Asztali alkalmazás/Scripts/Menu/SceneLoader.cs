using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LogicManager : MonoBehaviour
{
    public GameObject settings;
    public GameObject menu;
    public SaveManager saveManager;
    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Back()
    {
        settings.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Settings()
    {
        menu.gameObject.SetActive(false);
        settings.gameObject.SetActive(true);
    }
    public void NewGame()
    {
        File.Delete(Application.dataPath+"/"+$"{DBManager.username}.dat");
        File.Delete(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat");
        File.Delete(Application.dataPath+"/"+$"{DBManager.username}WorldBosses2.dat");
        File.Delete(Application.dataPath+"/"+$"{DBManager.username}Shop.dat");
        File.Delete(Application.dataPath+"/"+$"{DBManager.username}CritShop.dat");
        File.Delete(Application.dataPath+"/"+$"{DBManager.username}Coin.dat");
        File.Delete(Application.dataPath+"/"+$"{DBManager.username}class.dat");
        File.Delete(Application.dataPath+"/"+$"{DBManager.username}RegenShop.dat");
        SceneManager.LoadScene("Character Selector");
    }
    public void LoadGame()
    {
        if (new FileInfo(Application.dataPath+"/"+$"{DBManager.username}.dat").Length!=0)
        {
            SceneManager.LoadScene("Level selector");
        }
    }
    public void Levelselector()
    {
        SceneManager.LoadScene("Level selector");
    }
    public void Level1()
    {
        saveManager.LoadPlayerStatsCheck();
        SceneManager.LoadScene("Arena1");
    }
}

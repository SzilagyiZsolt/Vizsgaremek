using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnderTalePause : MonoBehaviour
{
    public bool visable = false;
    public GameObject deadpanel;
    public GameObject settings;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !visable)
        {
            visable = true;
            settings.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && visable)
        {
            visable = false;
            settings.SetActive(false);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deadpanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public bool disable = false;
    public PlayerHealt playerHealt;
    public GameObject settings;
    public GameObject pause;
    public GameObject deadpanel;
    public Upgrade upgrade; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playerHealt.alive && !upgrade.isOpen)
        {
            disable = true;
            Cursor.visible = true;
            PauseGame();
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
    public void Continue()
    {
        pause.SetActive(false);
        disable = false;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Back()
    {
        settings.gameObject.SetActive(false);
        pause.SetActive(true);
    }
    public void Settings()
    {
        settings.gameObject.SetActive(true);
        pause.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deadpanel.SetActive(false);
        Time.timeScale = 1f;
    }
}

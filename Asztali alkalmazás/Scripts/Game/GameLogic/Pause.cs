using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public ClassLoader classLoader;
    public KnightHealth knightHealth;
    public ArcherHealth archerHealth;
    public KnightMovement knightMovement;
    public ArcherMovement archerMovement;
    public bool disable =false;
    public Animator anim;
    public SaveManager saveManager;
    public GameObject settings;
    public GameObject pause;
    public GameObject deadpanel;
    private void Start()
    {
        GameObject logic = GameObject.FindGameObjectWithTag("LogicManager");
        classLoader = logic.GetComponent<ClassLoader>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !disable && knightMovement.alive && classLoader.isKnight)
        {
            disable = true;
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !disable && archerMovement.alive && !classLoader.isKnight)
        {
            disable = true;
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
        Time.timeScale = 1f;
        anim.SetBool("Pause", false);
        disable= false;
    }
    public void PauseGame()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        anim.SetBool("Pause", true);
    }
    public void Back()
    {
        disable = false;
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
    public void LevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
    }
}

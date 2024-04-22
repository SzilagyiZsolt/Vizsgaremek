using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnightDeath : MonoBehaviour
{
    public float timer;
    public KnightMovement knightMovement;
    public GameObject deadpanel;
    public GameObject HUD;
    public GameObject music;
    public KnightHealth knightHealth;
    public AudioManager audioManager;


    private void Start()
    {
        music.SetActive(false);
        audioManager.playSFX(audioManager.knightEffects[2]);
    }
    private void Update()
    {
        if (knightHealth.health <= 0)
        {
            timer += Time.deltaTime;
            Time.timeScale= 0.2f;
            if (timer > 1)
            {
                deadpanel.SetActive(true);
                HUD.SetActive(false);
                Time.timeScale = 1f;
            }
            knightMovement.anim.SetBool("Death", true);
            knightMovement.alive = false;
        }
    }
}

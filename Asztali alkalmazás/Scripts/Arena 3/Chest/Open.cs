using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{   
    public GameObject pistol;
    public GameObject rifle;
    public GameObject[] enemySpawners;
    public Animator anim;
    public AudioManager audioManager;
    public float timer;
    public bool open = false;

    private void Update()
    {
        if (open)
        {
            timer += Time.deltaTime;
        }
        if (timer > 1)
        {
            GiveRifle();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sprite"))
        {
            audioManager.playSFX(audioManager.arena3Effects[2]);
            anim.SetBool("Open", true);
            open = true;
        }
    }

    public void GiveRifle()
    {
        enemySpawners[0].SetActive(true);
        enemySpawners[1].SetActive(true);
        pistol.SetActive(false);
        rifle.SetActive(true);
        Destroy(gameObject);
    }
}

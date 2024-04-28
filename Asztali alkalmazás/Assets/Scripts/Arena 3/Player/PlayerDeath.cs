using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public PlayerHealt playerHealth;
    public Animator anim;
    public GameObject deadpanel;
    public BoxCollider2D boxCollider;
    public AudioManager audioManager;
    public GameObject music;
    public float timer;
    private void Start()
    {
        music.SetActive(false);
        audioManager.playSFX(audioManager.arena3Effects[3]);
    }

    void Update()
    {
        if (!playerHealth.alive)
        {
            timer += Time.deltaTime;
            anim.SetBool("Death", true);
            Destroy(boxCollider);
            if (timer > 1.5)
            {
                Cursor.visible = true;
                deadpanel.SetActive(true);
            }
        }
    }
}

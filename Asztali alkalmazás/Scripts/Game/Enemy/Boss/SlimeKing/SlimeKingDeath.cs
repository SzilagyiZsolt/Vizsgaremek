using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeKingDeath : MonoBehaviour
{
    public Animator anim;
    public float timer;
    public bool slimeKingAlive=true;
    public SaveManager saveManager;
    public GameObject text;
    public UnderTaleHP playerHP;
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    void Update()
    {
        if(playerHP.HP > 0)
        {
            timer += Time.deltaTime;
        }
        if (timer > 118)
        {
            anim.SetBool("Death", true);
            slimeKingAlive = false;
            if (timer>120)
            {
                saveManager.saveWorldBoss1();
                text.SetActive(true);
            }
            if (timer>123)
            {
                SceneManager.LoadScene("Level Selector");
            }
        }
    }
}

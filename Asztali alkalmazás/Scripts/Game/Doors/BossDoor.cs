using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDoor : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    public SaveManager saveManager;
    void Start()
    {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Open", true);
            if (Input.GetKey(KeyCode.E))
            {
                saveManager.saveWorldBoss2();
                saveManager.SaveCoin();
                SceneManager.LoadScene("Level Selector");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Open", false);
        }
    }
}

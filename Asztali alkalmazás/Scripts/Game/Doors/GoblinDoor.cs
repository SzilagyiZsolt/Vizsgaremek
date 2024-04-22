using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoblinDoor : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Open", true);

            if (Input.GetKey(KeyCode.E))
            {
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

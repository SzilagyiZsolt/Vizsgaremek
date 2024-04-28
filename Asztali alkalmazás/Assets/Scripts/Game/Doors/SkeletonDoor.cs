using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonDoor : MonoBehaviour
{
    public Animator anim;
    public SaveManager saveManager;
    public GameObject player;
    public GameObject background;
    public CinemachineVirtualCamera camera;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Open", true);

            if (Input.GetKey(KeyCode.E))
            {
                saveManager.SaveCoin();
                background.SetActive(false);
                CinemachineFramingTransposer composer = camera.GetCinemachineComponent<CinemachineFramingTransposer>();
                composer.m_DeadZoneHeight = 0.05f;
                camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0f, 0.5f, 0f);
                player.transform.position = new Vector2(25, 0);
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
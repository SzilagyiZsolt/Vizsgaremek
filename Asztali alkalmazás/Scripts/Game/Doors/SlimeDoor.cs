using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeDoor : MonoBehaviour
{
    public Animator anim;
    public SaveManager saveManager;
    public GameObject player;
    public GameObject background;
    public GameObject brownSlime;
    public CinemachineVirtualCamera camera;
    public GameObject camObj;
    public CinemachineFreeLook freeLook;
    public CinemachineComposer comp;
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
                brownSlime.SetActive(true);
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

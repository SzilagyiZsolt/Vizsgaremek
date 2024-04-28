using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSummon : MonoBehaviour
{
    public GameObject boss;
    public GameObject trigger;
    public CinemachineVirtualCamera knightCamera;
    public float timer;
    private void Update()
    {
        timer+=Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timer>1)
            {
                CinemachineFramingTransposer composer = knightCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
                composer.m_DeadZoneHeight = 2;
                boss.SetActive(true);
                trigger.SetActive(false);
            }
        }
    }
}

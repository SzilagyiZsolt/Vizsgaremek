using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassLoader : MonoBehaviour
{
    public SaveManager saveManager;
    public GameObject knight;
    public GameObject archer;
    public CinemachineVirtualCamera virtualCamera;
    public bool isKnight;
    void Start()
    {
        saveManager.ClassLoad();
        if (isKnight)
        {
            virtualCamera.Follow=knight.transform;
            knight.SetActive(true);
        }
        else
        {
            virtualCamera.Follow=archer.transform;
            archer.SetActive(true);
        }
    }
}

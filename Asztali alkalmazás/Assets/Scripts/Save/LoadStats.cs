using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadStats : MonoBehaviour
{
    public SaveManager saveManager;
    void Start()
    {
        saveManager.LoadPlayerStatsCheck();
        saveManager.LoadCoin();
    }
}

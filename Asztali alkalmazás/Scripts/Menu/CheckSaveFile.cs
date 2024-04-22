using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CheckSaveFile : MonoBehaviour
{
    public Text loadGame;

    private void Start()
    {
        if (new FileInfo(Application.dataPath+"/"+$"{DBManager.username}.dat").Length!=0)
        {
            loadGame.color = Color.white;
        }
    }
}

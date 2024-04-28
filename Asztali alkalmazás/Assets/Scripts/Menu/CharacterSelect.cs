using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Button knightButton;
    public Button archerButton;
    public SaveManager saveManager;
    public bool knightSelected=false;
    public void KnightSelect()
    {
        knightSelected = true;
        saveManager.ClassSelected();
        SceneManager.LoadScene("Tutorial");
    }
    public void ArcherSelect()
    {
        saveManager.ClassSelected();
        SceneManager.LoadScene("Tutorial");
    }
}

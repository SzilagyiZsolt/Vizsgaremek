using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeText : MonoBehaviour
{
    public Text welcomeText;
    void Start()
    {
        welcomeText.text=DBManager.username;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public void OpenWeb()
    {
        //Megnyitja a weboldalt
        Application.OpenURL("http://localhost/MysticRealm/");
    }
}
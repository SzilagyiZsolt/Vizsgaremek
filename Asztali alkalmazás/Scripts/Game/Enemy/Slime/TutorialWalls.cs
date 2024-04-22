using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWalls : MonoBehaviour
{
    public GameObject[] wall;
    public SlimeHealth slimeHealth;

    void Update()
    {
        if (slimeHealth.slimeHealth<=0)
        {
            wall[0].SetActive(false);
            wall[1].SetActive(false);
            wall[2].SetActive(false);
        }
        
    }
}

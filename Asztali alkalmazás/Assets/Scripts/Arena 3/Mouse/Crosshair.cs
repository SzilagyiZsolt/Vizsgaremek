using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GamePause pause;
    public PlayerHealt playerHealt;
    private void Awake()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector2 Crosshair = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Crosshair;
        if (!pause.disable && playerHealt.alive)
        {
            Cursor.visible = false;
        }
        
    }
}

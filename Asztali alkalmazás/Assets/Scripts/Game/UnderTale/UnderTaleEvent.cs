using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnderTaleEvent : MonoBehaviour
{
    public float timer;
    public bool isOn=false;
    public Elevator elevator;
    void Update()
    {
        if (isOn)
        {
            elevator.isOn = false;
            timer+=Time.deltaTime;
            if (timer > 1)
            {
                SceneManager.LoadScene("UnderTaleEvent");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Elevator"))
        {
            isOn = true;
        }
    }
}

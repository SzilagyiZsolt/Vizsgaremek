using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWarning : MonoBehaviour
{
    public float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            Destroy(gameObject);
        }
    }
}

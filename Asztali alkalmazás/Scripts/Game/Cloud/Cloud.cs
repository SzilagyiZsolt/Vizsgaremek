using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float strength;
    public float deadZone;

    private void Update()
    {
        if (transform.position.x < deadZone)
        {
            Debug.Log("Destroyed!");
            Destroy(gameObject);
        }
        transform.position += (Vector3.left * strength) * Time.deltaTime;
    }
}

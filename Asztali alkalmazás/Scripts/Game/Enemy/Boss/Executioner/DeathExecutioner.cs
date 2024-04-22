using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExecutioner : MonoBehaviour
{
    public float timer;
    public HealthExecutioner executionerHealth;
    public GameObject bossDoor;
    private void Start()
    {
        executionerHealth = GetComponent<HealthExecutioner>();
    }
    private void Update()
    {
        if (executionerHealth.executionerHealth <= 0)
        {
            timer += Time.deltaTime;
            if (timer > 1.7)
            {
                bossDoor.SetActive(true);
                Destroy(gameObject);
            }
            executionerHealth.anim.SetBool("Death", true);
            executionerHealth.executioneralive = false;
        }
    }
}
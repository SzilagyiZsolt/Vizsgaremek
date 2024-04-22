using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnderTaleHP : MonoBehaviour
{
    public int HP;
    public int db;
    public GameObject deadPanel;
    public GameObject[] heart;
    private void Update()
    {
        if (HP<=0)
        {
            deadPanel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack") && HP>0)
        {
            Destroy(heart.ElementAt(db));
            db--;
            HP--;
        }
    }
}

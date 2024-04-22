using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    public EnemyDeath4 enemyDeath;
    public PlayerEXP playerExp;
    public float timer;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerExp = player.GetComponent<PlayerEXP>();
        enemyDeath = GetComponentInParent<EnemyDeath4>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sprite") && enemyDeath.timer > 2)
        {
            GiveEXP();
        }
    }

    public void GiveEXP()
    {
        playerExp.playerEXP += 5;
        Destroy(enemyDeath.gameObject);
    }
}

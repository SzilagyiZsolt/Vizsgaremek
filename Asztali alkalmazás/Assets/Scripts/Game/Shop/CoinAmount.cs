using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAmount : MonoBehaviour
{
    public float timer;
    [HideInInspector] public GameObject coin;
    [HideInInspector] public GameObject enemy;
    void Start()
    {
        SpawnCoin();
    }
    public void SpawnCoin()
    {
        Instantiate(coin, new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0), transform.rotation);
    }
}

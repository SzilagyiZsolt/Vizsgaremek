using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
public class ShopCritRateText : MonoBehaviour
{
    public int price;
    public float critRate;
    public int coin;
    public Text priceText;
    public Text CritRateText;
    public Text coinText;
    private void Start()
    {
        priceText.text=price.ToString();
        CritRateText.text=critRate.ToString();
    }
    private void Update()
    {
        price=int.Parse(priceText.text);
        coin=int.Parse(coinText.text);
    }
    public void CritRateBuy()
    {
        if (coin>=int.Parse(priceText.text))
        {
            coin -= int.Parse(priceText.text);
            coinText.text=coin.ToString();
            price*=2;
            priceText.text=price.ToString();
            critRate+=1;
            CritRateText.text=critRate.ToString();
        }
    }
}

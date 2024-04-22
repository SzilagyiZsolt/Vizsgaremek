using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
public class ShopCritDMGText : MonoBehaviour
{
    public int price;
    public float critDMG;
    public int coin;
    public Text priceText;
    public Text CritDMGText;
    public Text coinText;
    private void Start()
    {
        priceText.text=price.ToString();
        CritDMGText.text=critDMG.ToString();
    }
    private void Update()
    {
        price=int.Parse(priceText.text);
        coin=int.Parse(coinText.text);
    }
    public void CritDMGBuy()
    {
        if (coin>=int.Parse(priceText.text))
        {
            coin -= int.Parse(priceText.text);
            coinText.text=coin.ToString();
            price+=10;
            priceText.text=price.ToString();
            critDMG+=5;
            CritDMGText.text=critDMG.ToString();
        }
    }
}

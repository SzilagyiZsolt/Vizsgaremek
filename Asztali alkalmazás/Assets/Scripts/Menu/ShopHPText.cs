using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
public class ShopHPText : MonoBehaviour
{
    public int price;
    public float HP;
    public int coin;
    public Text priceText;
    public Text MaxHPText;
    public Text coinText;
    private void Start()
    {
        priceText.text=price.ToString();
        MaxHPText.text=HP.ToString();
    }
    private void Update()
    {    
        price=int.Parse(priceText.text);
        coin=int.Parse(coinText.text);
    }
    public void HPBuy()
    {
        if (coin>=int.Parse(priceText.text))
        {
            coin -= int.Parse(priceText.text);
            coinText.text=coin.ToString();
            price++;
            priceText.text=price.ToString();
            HP+=10;
            MaxHPText.text=HP.ToString();
        }
    }
}

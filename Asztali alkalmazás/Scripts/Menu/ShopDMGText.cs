using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDMGText : MonoBehaviour
{
    public int price;
    public float DMG;
    public ShopHPText shopHPText;
    public Text coinText;
    public Text priceText;
    public Text DMGText;
    private void Start()
    {
        GameObject HPText = GameObject.FindWithTag("ShopHP");
        shopHPText=HPText.GetComponent<ShopHPText>();
        priceText.text=price.ToString();
        DMGText.text=DMG.ToString();
    }
    private void Update()
    {
        price=int.Parse(priceText.text);
    }
    public void DMGBuy()
    {
        if (shopHPText.coin>=int.Parse(priceText.text))
        {
            shopHPText.coin -= int.Parse(priceText.text);
            coinText.text=shopHPText.coin.ToString();
            price++;
            priceText.text=price.ToString();
            DMG+=5;
            DMGText.text=DMG.ToString();
        }
    }
}

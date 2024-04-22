using System;
using System.Numerics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class SaveData
{
    public ClassData MyClassData { get; set; }
    public PlayerData MyPlayerData {  get; set; }
    public PlayerWithCritData MyPlayerWithCritData {  get; set; }
    public PlayerCoin MyPlayerCoin {  get; set; }
    public ShopData MyShopData { get; set; }
    public ShopCritData MyShopCritData { get; set; }
    public SkeletonKingData SkeletonKingData { get; set; }
    public BrownSlimeData BrownSlimeData { get; set; }
    public WorldBoss1Data WorldBoss1Data { get; set; }
    public WorldBoss2Data WorldBoss2Data { get; set; }

public SaveData() 
    {
        
    }

}
[Serializable]
public class ClassData
{
    public bool MyClass { get; set; }
    public ClassData(bool myclass)
    {
        this.MyClass = myclass;
    }
}


[Serializable]
public class PlayerData
{
    public float MyMaxHP { get; set; }
    public float MyDamage { get; set; }
    public int MyCoin { get; set; }
    public PlayerData(int coin,float MaxHP, float Damage) 
    {
        this.MyCoin = coin;
        this.MyMaxHP=MaxHP;
        this.MyDamage=Damage;
    }
}


[Serializable]
public class PlayerWithCritData
{
    public float MyMaxHP { get; set; }
    public float MyDamage { get; set; }
    public string MyCritRate { get; set; }
    public string MyCritDMG { get; set; }
    public int MyCoin { get; set; }
    public PlayerWithCritData(int coin, float MaxHP, float Damage, string critRate, string critDMG)
    {
        this.MyCoin = coin;
        this.MyMaxHP=MaxHP;
        this.MyDamage=Damage;
        this.MyCritRate=critRate;
        this.MyCritDMG=critDMG;
    }
}

[Serializable]
public class PlayerCoin
{
    public int MyCoin { get; set; }
    public PlayerCoin(int coin)
    {
        this.MyCoin = coin;
    }
}
[Serializable]
public class SkeletonKingData
{
    public int SkeletonKingXP { get; set; }
    public SkeletonKingData(int skeletonKingXP)
    {
        this.SkeletonKingXP = skeletonKingXP;
    }
}
[Serializable]
public class BrownSlimeData
{
    public int BrownSlimeXP { get; set; }
    public BrownSlimeData(int brownSlimeXP)
    {
        this.BrownSlimeXP = brownSlimeXP;
    }
}

[Serializable]
public class ShopData
{
    public int HPPrice { get; set; }
    public int DMGPrice { get; set; }
    public float DMGText { get; set; }
    public float HPText { get; set; }
    public ShopData(int hpprice, int dmgprice, float dmgtext, float hptext)
    {
        this.HPPrice=hpprice;
        this.DMGPrice=dmgprice;
        this.DMGText=dmgtext;
        this.HPText=hptext;
    }
}
[Serializable]
public class ShopCritData
{
    public int HPPrice { get; set; }
    public int DMGPrice { get; set; }
    public int CritDMGPrice { get; set; }
    public int CritRatePrice { get; set; }
    public float DMGText { get; set; }
    public float HPText { get; set; }
    public string CritRateText { get; set; }
    public string CritDMGText { get; set; }
    public ShopCritData(int hpprice, int dmgprice, float dmgtext, float hptext, string critratetext, string critdmgtext, int critrateprice, int critdmgprice)
    {
        this.HPPrice=hpprice;
        this.DMGPrice=dmgprice;
        this.CritRatePrice=critrateprice;
        this.CritDMGPrice=critdmgprice;
        this.DMGText=dmgtext;
        this.HPText=hptext;
        this.CritRateText=critratetext;
        this.CritDMGText=critdmgtext;
    }
}

[Serializable]
public class WorldBoss1Data
{
    public bool Defeated {  get; set; }
    public WorldBoss1Data(bool defeated)
    {
        this.Defeated=defeated;
    }
}
[Serializable]
public class WorldBoss2Data
{
    public bool Defeated {  get; set; }
    public WorldBoss2Data(bool defeated)
    {
        this.Defeated=defeated;
    }
}

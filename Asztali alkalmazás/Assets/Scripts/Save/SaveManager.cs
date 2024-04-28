using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SaveManager : MonoBehaviour
{
    public CharacterSelect characterSelect;
    public ClassLoader classLoader;
    public KnightXP knightXP;
    public KnightHealth knightHealth;
    public KnightAttack knightAttack;
    public ArcherXP archerXP;
    public ArcherHealth archerHealth;
    public ArcherAttack archerAttack;
    public ShopHPText hpText;
    public ShopDMGText dmgText;
    public ShopCritDMGText critDMGText;
    public ShopCritRateText critRateText;
    public XPSkeletonKing xpSkeletonKing;
    public XPBrownSlime brownSlimeXP;
    public SlimeKingDeath SlimeKingDeath;
    public LevelButtons levelButtons;
    public GameObject CritRate;
    public GameObject CritDMG;
    public Text DMGText;
    public Text HPText;
    public Text CritRateText;
    public Text CritDMGText;
    public Text coinText;

    public void ClassSelected()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}class.dat");
            SaveData data = new SaveData();
            Classselected(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void Classselected(SaveData data)
    {
        data.MyClassData=new ClassData(characterSelect.knightSelected);
    }
    public void ClassLoad()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}class.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            ClassLoadData(data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void ClassLoadData(SaveData data)
    {
        classLoader.isKnight = data.MyClassData.MyClass;
    }


    public void TutorialSave()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            TutorialSavePlayerData(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void TutorialSavePlayerData(SaveData data)
    {
        if (classLoader.isKnight)
        {
            data.MyPlayerData=new PlayerData(knightXP.coinAmount, knightXP.knightHealth.maxHealth, knightXP.knightAttack.damage);
        }
        else
        {
            data.MyPlayerData=new PlayerData(archerXP.coinAmount, archerXP.archerHealth.maxHealth, archerXP.archerAttack.damage);
        }
        
    }


    public void SavePlayerStats()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            SavePlayerStatsData(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerStatsData(SaveData data)
    {
        if (classLoader.isKnight)
        {
            data.MyPlayerCoin=new PlayerCoin(knightXP.coinAmount);
        }
        else
        {
            data.MyPlayerCoin=new PlayerCoin(archerXP.coinAmount);
        }
    }


    public void LoadPlayerStatsCheck()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses2.dat"))
        {
            LoadPlayerStatsWithCrit();
        }
        else 
        {
            LoadPlayerStats(); 
        }
    }
    public void LoadPlayerStats()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            LoadPlayerData(data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadPlayerData(SaveData data)
    {
        if (classLoader.isKnight)
        {
            knightXP.coinAmount=data.MyPlayerData.MyCoin;
            knightHealth.maxHealth=data.MyPlayerData.MyMaxHP;
            knightAttack.damage=data.MyPlayerData.MyDamage;
        }
        else
        {
            archerXP.coinAmount=data.MyPlayerData.MyCoin;
            archerHealth.maxHealth=data.MyPlayerData.MyMaxHP;
            archerAttack.damage=data.MyPlayerData.MyDamage;
        }
    }


    public void LoadPlayerStatsWithCrit()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            LoadPlayerWithCritData(data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadPlayerWithCritData(SaveData data)
    {
        if(classLoader.isKnight)
        {
            knightXP.coinAmount=data.MyPlayerWithCritData.MyCoin;
            knightHealth.maxHealth=data.MyPlayerWithCritData.MyMaxHP;
            knightAttack.damage=data.MyPlayerWithCritData.MyDamage;
            knightAttack.critRate=float.Parse(data.MyPlayerWithCritData.MyCritRate);
            knightAttack.critDMG=float.Parse(data.MyPlayerWithCritData.MyCritDMG);
        }
        else
        {
            archerXP.coinAmount=data.MyPlayerWithCritData.MyCoin;
            archerHealth.maxHealth=data.MyPlayerWithCritData.MyMaxHP;
            archerAttack.damage=data.MyPlayerWithCritData.MyDamage;
            archerAttack.critRate=float.Parse(data.MyPlayerWithCritData.MyCritRate);
            archerAttack.critDMG=float.Parse(data.MyPlayerWithCritData.MyCritDMG);
        }
    }


    public void SaveCheck()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses2.dat"))
        {
            SavePlayerWithCrit();
        }
        else if (!File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat"))
        {
            SavePlayer();
        }
    }
    public void SavePlayer()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            SavePlayerData(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerData(SaveData data)
    {
        data.MyPlayerData=new PlayerData(int.Parse(hpText.coinText.text), float.Parse(hpText.MaxHPText.text), float.Parse(dmgText.DMGText.text));
    }


    public void SavePlayerWithCrit()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            SavePlayerWithCritData(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerWithCritData(SaveData data)
    {
        data.MyPlayerWithCritData=new PlayerWithCritData(int.Parse(hpText.coinText.text), float.Parse(hpText.MaxHPText.text), float.Parse(dmgText.DMGText.text), critRateText.CritRateText.text, critDMGText.CritDMGText.text);
    }


    public void LoadCritShopDefault()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}CritShop.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Shop.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                LoadCritShopdataDefault(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadCritShopdataDefault(SaveData CritShopdata)
    {
        dmgText.price=CritShopdata.MyShopData.DMGPrice;
        hpText.price=CritShopdata.MyShopData.HPPrice;
        hpText.HP=CritShopdata.MyShopData.HPText;
        dmgText.DMG=CritShopdata.MyShopData.DMGText;
    }


    public void LoadRegenShopDefault()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}RegenShop.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Shop.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                LoadRegenShopdataDefault(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadRegenShopdataDefault(SaveData CritShopdata)
    {
        dmgText.price=CritShopdata.MyShopData.DMGPrice;
        hpText.price=CritShopdata.MyShopData.HPPrice;
        hpText.HP=CritShopdata.MyShopData.HPText;
        dmgText.DMG=CritShopdata.MyShopData.DMGText;
    }


    public void LoadCritShop()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat") && File.Exists(Application.dataPath+"/"+$"{DBManager.username}CritShop.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses2.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}CritShop.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                LoadCritShopdata(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadCritShopdata(SaveData CritShopdata)
    {
        dmgText.price=CritShopdata.MyShopCritData.DMGPrice;
        hpText.price=CritShopdata.MyShopCritData.HPPrice;
        hpText.HP=CritShopdata.MyShopCritData.HPText;
        dmgText.DMG=CritShopdata.MyShopCritData.DMGText;
        critDMGText.critDMG=float.Parse(CritShopdata.MyShopCritData.CritDMGText);
        critRateText.critRate=float.Parse(CritShopdata.MyShopCritData.CritRateText);
        critDMGText.price=CritShopdata.MyShopCritData.CritDMGPrice;
        critRateText.price=CritShopdata.MyShopCritData.CritRatePrice;
    }


    public void CritShopLoadCheck()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}CritShop.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses2.dat"))
        {
            LoadCritShop();
        }
        else if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}CritShop.dat"))
        {
            LoadCritShopDefault();
        }
        else if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses2.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}RegenShop.dat"))
        {
            LoadRegenShopDefault();
        }
        else if(!File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat") && File.Exists(Application.dataPath+"/"+$"{DBManager.username}Shop.dat"))
        {
            LoadShop();
        }
    }
    public void CritShopSaveCheck()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat") && !File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses2.dat"))
        {
            SaveCritShop();
        }
        else
        {
            SaveShop();
        }
    }


    public void SaveShop()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}Shop.dat");
            SaveData Shopdata = new SaveData();
            SaveShopData(Shopdata);
            bf.Serialize(file, Shopdata);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SaveShopData(SaveData Shopdata)
    {
        Shopdata.MyShopData=new ShopData(hpText.price, dmgText.price, float.Parse(DMGText.text), float.Parse(HPText.text));
    }


    public void SaveCritShop()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}CritShop.dat");
            SaveData Shopdata = new SaveData();
            SaveShopCritData(Shopdata);
            bf.Serialize(file, Shopdata);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SaveShopCritData(SaveData Shopdata)
    {
        Shopdata.MyShopCritData=new ShopCritData(hpText.price, dmgText.price, float.Parse(DMGText.text), float.Parse(HPText.text), CritRateText.text, CritDMGText.text, critRateText.price, critDMGText.price);
    }


    public void LoadDefaultShop()
    {
        if (!File.Exists(Application.dataPath+"/"+$"{DBManager.username}Shop.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                LoadDefaultShopdata(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadDefaultShopdata(SaveData Shopdata)
    {
        hpText.HP=Shopdata.MyPlayerData.MyMaxHP;
        dmgText.DMG=Shopdata.MyPlayerData.MyDamage;
        hpText.MaxHPText.text=Shopdata.MyPlayerData.MyMaxHP.ToString();
        dmgText.DMGText.text=Shopdata.MyPlayerData.MyDamage.ToString();
        hpText.coinText.text=Shopdata.MyPlayerData.MyCoin.ToString();
    }


    public void SaveCoin()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}Coin.dat");
            SaveData data = new SaveData();
            SavePlayerCoin(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerCoin(SaveData data)
    {
        if (classLoader.isKnight)
        {
            data.MyPlayerCoin=new PlayerCoin(knightXP.coinAmount);
        }
        else
        {
            data.MyPlayerCoin=new PlayerCoin(archerXP.coinAmount);
        }
        
    }


    public void SaveCoinShop()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}Coin.dat");
            SaveData data = new SaveData();
            SavePlayerCoinShop(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerCoinShop(SaveData data)
    {
        data.MyPlayerCoin=new PlayerCoin(int.Parse(hpText.coinText.text));
    }


    public void LoadCoinShop()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}Coin.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Coin.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                LoadCoinDataShop(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadCoinDataShop(SaveData Shopdata)
    {
        hpText.coinText.text=Shopdata.MyPlayerCoin.MyCoin.ToString();
    }


    public void LoadCoin()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}Coin.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Coin.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                LoadCoinData(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadCoinData(SaveData Shopdata)
    {
        knightXP.coinAmount=Shopdata.MyPlayerCoin.MyCoin;
    }


    public void LoadShop()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Shop.dat", FileMode.Open);
            SaveData Shopdata2 = (SaveData)bf.Deserialize(file);
            LoadShopData(Shopdata2);
            file.Close();
            
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadShopData(SaveData Shopdata2)
    {
        dmgText.price=Shopdata2.MyShopData.DMGPrice;
        hpText.price=Shopdata2.MyShopData.HPPrice;
        hpText.HP=Shopdata2.MyShopData.HPText;
        dmgText.DMG=Shopdata2.MyShopData.DMGText;
    }


    public void loadSkeletonKing()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}SecretBossSkeletonKing.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            LoadSkeletonKing(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadSkeletonKing(SaveData data)
    {
        xpSkeletonKing.skeletonKingLevel=data.SkeletonKingData.SkeletonKingXP;
    }


    public void saveSkeletonKing()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}SecretBossSkeletonKing.dat");
            SaveData data = new SaveData();
            SaveSkeletonKing(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SaveSkeletonKing(SaveData data)
    {
        data.SkeletonKingData=new SkeletonKingData(xpSkeletonKing.skeletonKingLevel);
    }


    public void loadBrownSlime()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}SecretBossBrownSlime.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            LoadBrownSlime(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadBrownSlime(SaveData data)
    {
        brownSlimeXP.brownSlimeLevel=data.BrownSlimeData.BrownSlimeXP;
    }


    public void saveBrownSlime()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}SecretBossBrownSlime.dat");
            SaveData data = new SaveData();
            SaveBrownSlime(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    } 
    public void SaveBrownSlime(SaveData data)
    {
        data.BrownSlimeData=new BrownSlimeData(brownSlimeXP.brownSlimeLevel);
    }


    public void saveWorldBoss1()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat");
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void loadWorldBoss1()
    {
        if(File.Exists(Application.dataPath+"/"+$"{DBManager.username}WorldBosses.dat"))
        {
            CritRate.SetActive(true);
            CritDMG.SetActive(true);
        }
    }


    public void saveWorldBoss2()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}WorldBosses2.dat");
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
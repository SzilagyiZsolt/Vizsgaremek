using System;
using System.Numerics;
using UnityEngine.SceneManagement;

[Serializable]
public class Settings
{
    public PlayerSettings MySettings { get; set; }
    public Settings()
    {

    }

}
[Serializable]
public class PlayerSettings
{
    public int MyMusic { get; set; }
    public int MySoundEffects { get; set; }
    public PlayerSettings(int MyMusic, int MySoundEffects)
    {
        this.MyMusic = MyMusic;
        this.MySoundEffects = MySoundEffects;
    }

}

using System;
using System.Numerics;
using UnityEngine.SceneManagement;

[Serializable]
public class UserName
{
    public PlayerName MyPlayerName { get; set; }
    public UserName()
    {

    }

}
[Serializable]
public class PlayerName
{
    public string MyName { get; set; }
    public PlayerName(string UserName)
    {
        this.MyName=UserName;
    }

}

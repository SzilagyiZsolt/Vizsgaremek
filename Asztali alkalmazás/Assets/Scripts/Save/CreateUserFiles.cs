using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class CreateUserFiles : MonoBehaviour
{
    public void Save() // Mentési metódus definiálása
    {
        try
        {
            // Fájl létrehozása vagy megnyitása az alkalmazás adatmappájában a felhasználónév alapján
            FileStream file = File.Open(Application.dataPath + "/" + $"{DBManager.username}.dat", FileMode.OpenOrCreate);
            file.Close(); // Fájl bezárása
        }
        catch (System.Exception) 
        {
            throw;
        }
    }
}

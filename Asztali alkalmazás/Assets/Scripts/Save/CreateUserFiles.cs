using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class CreateUserFiles : MonoBehaviour
{
    public void Save() // Ment�si met�dus defini�l�sa
    {
        try
        {
            // F�jl l�trehoz�sa vagy megnyit�sa az alkalmaz�s adatmapp�j�ban a felhaszn�l�n�v alapj�n
            FileStream file = File.Open(Application.dataPath + "/" + $"{DBManager.username}.dat", FileMode.OpenOrCreate);
            file.Close(); // F�jl bez�r�sa
        }
        catch (System.Exception) 
        {
            throw;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    // Statikus v�ltoz� a felhaszn�l�n�v t�rol�s�ra
    public static string username;

    // Logika az bejelentkez�s �llapot ellen�rz�s�re
    public static bool LoggedIn
    {
        get
        {
            // Ha a felhaszn�l�n�v �rt�ke nem null, akkor a felhaszn�l� be van jelentkezve
            return username != null;
        }
    }

    // Met�dus a felhaszn�l� kijelentkeztet�s�re
    public static void LogOut()
    {
        // Felhaszn�l�n�v �rt�k�nek t�rl�se
        username = null;
    }
}

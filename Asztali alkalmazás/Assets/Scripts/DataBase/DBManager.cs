using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    // Statikus változó a felhasználónév tárolására
    public static string username;

    // Logika az bejelentkezés állapot ellenõrzésére
    public static bool LoggedIn
    {
        get
        {
            // Ha a felhasználónév értéke nem null, akkor a felhasználó be van jelentkezve
            return username != null;
        }
    }

    // Metódus a felhasználó kijelentkeztetésére
    public static void LogOut()
    {
        // Felhasználónév értékének törlése
        username = null;
    }
}

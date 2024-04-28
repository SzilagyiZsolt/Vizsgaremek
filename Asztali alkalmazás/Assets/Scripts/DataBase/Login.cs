using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    // A Login osztály, amely felelõs a bejelentkezésért

    // Idõzítõ a hibaüzenet eltûntetésére
    public float timer;

    // CreateUserFiles osztály példánya a fájlok létrehozásához
    public CreateUserFiles createUserFiles;

    // Hibaüzenet megjelenítésére szolgáló GameObject
    public GameObject error;

    // Felhasználónév és jelszó beviteli mezõk
    public InputField nameField;
    public InputField passwordField;

    // Bejelentkezés gomb
    public Button LoginButton;

    // Idõzítõ frissítése
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            error.SetActive(false); // Ha a timer több, mint 3 másodperc, elrejti a hibaüzenetet
        }
    }

    // Bejelentkezés hívása
    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    // Játékos bejelentkeztetése
    IEnumerator LoginPlayer()
    {
        // PHP oldal felé küldött adatok összeállítása
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        // Bejelentkezési adatok elküldése a szervernek
        WWW www = new WWW("http://localhost/Vizsga%20game/Login.php", form);
        yield return www;

        // Ha a válasz elsõ karaktere 0
        if (www.text[0] == '0')
        {
            // Felhasználónév tárolása
            DBManager.username = nameField.text;

            // Menü jelenítése
            SceneManager.LoadScene("Menu");

            // Ha még nincs fájl létrehozva a felhasználóhoz
            if (!File.Exists(Application.dataPath + "/" + $"{nameField.text}.dat"))
            {
                // Fájl létrehozása
                createUserFiles.Save();
            }
        }
        else
        {
            // Hiba esetén hibaüzenet kiírása és idõzítõ nullázása
            Debug.Log("User login failed. Error #" + www.text);
            error.SetActive(true);
            timer = 0;
        }
    }

    // Beviteli mezõk ellenõrzése
    public void VerfyInputs()
    {
        LoginButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 5);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    // A Login oszt�ly, amely felel�s a bejelentkez�s�rt

    // Id�z�t� a hiba�zenet elt�ntet�s�re
    public float timer;

    // CreateUserFiles oszt�ly p�ld�nya a f�jlok l�trehoz�s�hoz
    public CreateUserFiles createUserFiles;

    // Hiba�zenet megjelen�t�s�re szolg�l� GameObject
    public GameObject error;

    // Felhaszn�l�n�v �s jelsz� beviteli mez�k
    public InputField nameField;
    public InputField passwordField;

    // Bejelentkez�s gomb
    public Button LoginButton;

    // Id�z�t� friss�t�se
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            error.SetActive(false); // Ha a timer t�bb, mint 3 m�sodperc, elrejti a hiba�zenetet
        }
    }

    // Bejelentkez�s h�v�sa
    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    // J�t�kos bejelentkeztet�se
    IEnumerator LoginPlayer()
    {
        // PHP oldal fel� k�ld�tt adatok �ssze�ll�t�sa
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        // Bejelentkez�si adatok elk�ld�se a szervernek
        WWW www = new WWW("http://localhost/Vizsga%20game/Login.php", form);
        yield return www;

        // Ha a v�lasz els� karaktere 0
        if (www.text[0] == '0')
        {
            // Felhaszn�l�n�v t�rol�sa
            DBManager.username = nameField.text;

            // Men� jelen�t�se
            SceneManager.LoadScene("Menu");

            // Ha m�g nincs f�jl l�trehozva a felhaszn�l�hoz
            if (!File.Exists(Application.dataPath + "/" + $"{nameField.text}.dat"))
            {
                // F�jl l�trehoz�sa
                createUserFiles.Save();
            }
        }
        else
        {
            // Hiba eset�n hiba�zenet ki�r�sa �s id�z�t� null�z�sa
            Debug.Log("User login failed. Error #" + www.text);
            error.SetActive(true);
            timer = 0;
        }
    }

    // Beviteli mez�k ellen�rz�se
    public void VerfyInputs()
    {
        LoginButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 5);
    }
}

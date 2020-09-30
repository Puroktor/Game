using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Dificalty : MonoBehaviour {


    void OnGUI()
    {

        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.fontSize = 20;
        style.fontStyle = FontStyle.Bold;

        GUI.Box(new Rect(Screen.width / 2 - 295, Screen.height / 2 - 250, 500, 525), "\nСложность",style);
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 160, 300, 100), "Лёгкая"))
        {
            PlayerPrefs.SetInt("Dificalty",5);
            SceneManager.LoadScene("Main");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 -10, 300, 100), "Средняя"))
        {
            PlayerPrefs.SetInt("Dificalty", 4);
            SceneManager.LoadScene("Main");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 140, 300, 100), "Хардкор"))
        {
            PlayerPrefs.SetInt("Dificalty", 3);
            SceneManager.LoadScene("Main");
        }
    }
    }

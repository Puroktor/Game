using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour {

    void OnGUI()
    {
            GUI.Box(new Rect(Screen.width / 2 - 295, Screen.height / 2 - 250, 500, 490), "");
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 300, 100), "Начать заново"))
            {
                SceneManager.LoadScene("Main");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 50, 300, 100), "Выход"))
            {
                Application.Quit();
            }
    }
}

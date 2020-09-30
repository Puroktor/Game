using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timeout : MonoBehaviour {

    private Character player;
    private Text text;
    private void Awake()
    {
        player = FindObjectOfType<Character>();
        text = GetComponent<Text>();
    }
	void Update () {
        if (player.Timeout > 1f)
        { text.text = "Готов!"; }
        else text.text = (1-player.Timeout).ToString("0.##");
    }
}

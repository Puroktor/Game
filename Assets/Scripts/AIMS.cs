using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIMS : MonoBehaviour {

    private int a = 0;
    private Monster monstr;
    private Text text;
    private Character charac;
    private int b = 0;

    private void Awake()
    {
        text = GetComponent<Text>();
        monstr = FindObjectOfType<Monster>();
        charac = FindObjectOfType<Character>();
    }
	void FixedUpdate () {
        if (a == 0)
        {
            try { Vector2 position = monstr.transform.position; } catch { a = 1; }
         }

        if (a > 0 && b ==0)
        {
            text.text = "Идите напрво, убивая монстров ";
            b = 1;
        }

        if (charac.transform.position.x > 67)
        {
            text.text = "Прыгнете в дыру в земле ";
        }
	}
}

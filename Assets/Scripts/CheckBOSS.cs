using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckBOSS : MonoBehaviour {

    [SerializeField]
    private Obstacles spikes1;
    [SerializeField]
    private Obstacles spikes2;
    [SerializeField]
    private Obstacles spikes3;
    [SerializeField]
    private Obstacles spikes4;
    [SerializeField]
    private Transform corner;
    [SerializeField]
    private Transform corner2;
    [SerializeField]
    private BOSS bosss;
    [SerializeField]
    private Transform character;
    [SerializeField]
    private Obstacles spike;
    [SerializeField]
    private Obstacles spike6;
    [SerializeField]
    private Obstacles spike7;
    [SerializeField]
    private ParticleSystem particip;
    [SerializeField]
    private ParticleSystem particip2;
    private int boss = 0;
    [SerializeField]
    private Transform monster;
    [SerializeField]
    private Text text;


	void FixedUpdate () {
        try
        {
            if (boss == 0 && character.transform.position.x > 47.0f)
            {
                boss = 1;
                spikes1.gameObject.SetActive(true);
                spikes2.gameObject.SetActive(true);
                spikes3.gameObject.SetActive(true);
                spikes4.gameObject.SetActive(true);
                corner.gameObject.SetActive(true);
                bosss.gameObject.SetActive(true);
                particip.gameObject.SetActive(true);
                particip2.gameObject.SetActive(true);
                spikes1.ReplaceUp = 1;
                spikes2.ReplaceUp = 1;
                spikes3.ReplaceUp = 1;
                spikes4.ReplaceUp = 1;
                text.text = "Победите босса ";
            }
        }
        catch { }

        try
        {
            Vector3 a=  bosss.transform.position;
        }
        catch
        {
            if (boss == 1)
            {
                boss = 2;
                spike.ReplaceDownS = 1.06;
                spike6.ReplaceDownS = 1.06;
                spike7.ReplaceDownS = 1.06;
                particip.Stop();
                particip2.Stop();
                monster.gameObject.SetActive(true);
                corner2.gameObject.SetActive(false);
                text.text = "Идите направо ";
            }
        }
    }
}

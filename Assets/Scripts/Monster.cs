using UnityEngine;
using System.Collections;

public class Monster : Unit {

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
            ReciveDamage();
    }

    public override void ReciveDamage()
    {
        sprite.color = Color.red;
        Invoke("Die",0.1f);
    }
}

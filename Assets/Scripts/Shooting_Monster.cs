using UnityEngine;
using System.Collections;

public class Shooting_Monster : Unit {

    private float rate = 2.0f;
    private Bullet bullet;
    private SpriteRenderer sprite;
    [SerializeField]
    private Color color = Color.white;

    private void Awake()
    {
        bullet = Resources.Load<Bullet>("shot");
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }
    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.3f; position.x -= 1.3f;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Coles = gameObject;
        newBullet.Direction = -transform.right;
        newBullet.Color = color;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            ReciveDamage();
        }
    }

    public override void ReciveDamage()
    {
        sprite.color = Color.red;
        Invoke("Die",0.1f);
    }
}

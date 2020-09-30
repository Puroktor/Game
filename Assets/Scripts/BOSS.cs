using UnityEngine;
using System.Collections;

public class BOSS : Unit {

    private Rigidbody2D rigibody;
    private SpriteRenderer sprite;
    private Character character;
    private float speed = 3.0f;
    private int lives= 5;
    private Bullet bullet;
   

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        character = FindObjectOfType<Character>();
        bullet = Resources.Load<Bullet>("shot");
    }
    private void Start() { InvokeRepeating("Shoot", 1.5f, 1.5f); }

    private void Update()
    {
        try
        {          
                if (lives == 0) Die();
                if (transform.position.x - character.transform.position.x > 0) { sprite.flipX = true; } else sprite.flipX = false;
                Vector3 dir = character.transform.position; if (dir.x > transform.position.x) dir.x -= 4f; else { dir.x += 4f; }
                transform.position = Vector3.MoveTowards(transform.position, dir, speed * Time.deltaTime);
            
        }
        catch { }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet && bullet.Coles.gameObject != gameObject)
        {
            ReciveDamage();
        }
    }

    public override void ReciveDamage()
    {
        lives--;
        sprite.color = Color.red;
        Invoke("ColorNorm", 0.3f);
        rigibody.velocity = Vector3.zero;
        rigibody.AddForce(transform.up * 5.0f, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.8f;

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Coles = gameObject;
        newBullet.Direction = transform.right * (sprite.flipX ? -1.0f : 1.0f);
        newBullet.Color = Color.red;
    }

    private void ColorNorm()
    {
        sprite.color = Color.white;
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class Bleg : Unit {

    private Animator animator;
    private int daying;
    private int lives=2;
    private SpriteRenderer sprite;
    private Rigidbody2D rigibody;
    private Vector3 dir;
    private Unit unit;
    private float damageRate;
    private int touching = 1;
    private float speed= 3.0f;
    private Vector3 direction;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rigibody = GetComponent<Rigidbody2D>();
        direction = transform.right;
    }

    private IntState State
    {
        get { return (IntState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Update()
    {
        if (daying != 1)
        {
            State = IntState.Idle;
            Move();
            if (touching == 0)
            {
                damageRate += Time.deltaTime;
                if (damageRate > 1.0f)
                {
                    damageRate = 0;
                    unit.ReciveDamage();
                }
            }
            if (lives == 0) { daying = 1;State = IntState.Die; Invoke("Die", 1); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (daying != 1)
        {
            Bullet bullet = collider.GetComponent<Bullet>();
            if (bullet)
            {
                dir = bullet.Direction;
                ReciveDamage();
            }
            BluegsPoint point = collider.GetComponent<BluegsPoint>();
            if (point) { direction *= -1.0f; sprite.flipX = direction.x > 0; }
        }
    }

    public override void ReciveDamage()
    {
        lives--;
        sprite.color = Color.red;
        Invoke("ColorNorm",0.1f);
        rigibody.velocity = Vector3.zero;
        rigibody.AddForce(dir* 2.0f, ForceMode2D.Impulse);
    }

    private void ColorNorm()
    {
        sprite.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (daying != 1)
        {
            Unit unit = coll.gameObject.GetComponent<Unit>();
            if (unit && unit is Character)
            {
                this.unit = unit;
                unit.ReciveDamage();
                touching = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        touching = 1;
        damageRate = 0;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}

public enum IntState
{
    Idle,
    Die
}
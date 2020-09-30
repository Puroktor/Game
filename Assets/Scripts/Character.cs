using UnityEngine;
using System.Collections;

public class Character : Unit
{
    private int hp;
    private int lives;
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float JumpForce = 15.0F;
   
    [SerializeField]
    public float fireRate = 1;
    public int Lives
    {
        get { return lives; }
        set
        {
            if(value<= hp) lives = value;
            bar.Refresh();
        }
    }
    private Rigidbody2D rigibody;
    private Animator animator;
    private SpriteRenderer spriterender;
    private bool isGrounded = false;
    [SerializeField]
    private Transform ground;
    private int daying = 0;
    private float timeout;
    public float Timeout { get { return timeout; } }
    private Vector3 direction;
    public Vector3 Direction { get { return direction; } }
    private Bullet bullet;
    private LivesBar bar;
    private GameObject odj;
    private int boss = 0;
    [SerializeField]
    private Transform End;
    


    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        hp = PlayerPrefs.GetInt("Dificalty");
        lives = hp;
        bar = FindObjectOfType<LivesBar>();
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("shot");
        odj = Resources.Load<GameObject>("Menu");
    }

    private void FixedUpdate()
    {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(ground.position,0.35F);
            isGrounded = colliders.Length >1;
        if (!(daying == 1))
        {
            if (!isGrounded) State = CharState.Jump;
        }            
        
        if (Lives <= 0)
        {
            State = CharState.Die;
            daying = 1;
            Invoke("Die",2); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (daying != 1)
        {
            Bullet bullet = collider.GetComponent<Bullet>();
            if (bullet && bullet.Coles.gameObject != gameObject)
            {
                ReciveDamage();
            }
            End end = collider.GetComponent<End>();
            if (end) { Transform ending = Instantiate(End); }
        }
    }

    private void Update()
    {
        timeout += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (timeout > 1f)
            {
                Fire();
                timeout = 0;
            }
        }
        if (!(daying==1)) { if (isGrounded) State = CharState.Idle; }
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    private void Run()
    {
        if (!(daying == 1))
        {
            if (isGrounded) State = CharState.Run;
            direction = transform.right * Input.GetAxis("Horizontal");


            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

            spriterender.flipX = direction.x < 0;
        }
    }

    private void Jump()
    {
        if (!(daying == 1))
        {
            rigibody.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void Fire()
    {
        if (!(daying == 1))
        {
            Vector3 position = transform.position;

            Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
            newBullet.Coles = gameObject;
            newBullet.Direction = transform.right * (spriterender.flipX ? -1.0f : 1.0f);
        }
    }
    public override void ReciveDamage()
    {
        if (!(daying == 1))
        {
            Lives--;
            spriterender.color = Color.red;
            Invoke("ColorNormalyse", 0.3f);
            rigibody.velocity = Vector3.zero;
            rigibody.AddForce(transform.up * 5.0f, ForceMode2D.Impulse);
        }
    }

    private void ColorNormalyse()
    {
        spriterender.color = Color.white;
    }

    protected override void Die()
    {
        Destroy(gameObject);
        GameObject menu = Instantiate(odj);
    }
}
    

public enum CharState
{
    Idle,
    Run,
    Jump,
    Die
}

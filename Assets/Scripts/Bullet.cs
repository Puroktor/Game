using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private GameObject parent;
    public GameObject Coles { set { parent = value; }   get {return parent;  } }
    private float speed = 16.0f;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } get { return direction; } }
    private SpriteRenderer sprite;
    private Color color = Color.white;
    public Color Color { set { color = value; } }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();       
    }
    void Start()
    { Destroy(gameObject,15); sprite.color = color; }
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position,transform.position+ direction, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Unit col = collider.GetComponent<Unit>();
        BluegsPoint point = collider.GetComponent<BluegsPoint>();
        if (!point)
        {
            try
            {
                if (col && parent != col.gameObject)
                { Destroy(gameObject); }
            }
            catch
            {

            }
            try
            {
                if (!col) { Destroy(gameObject); }
            }
            catch { }
        }
    }
}

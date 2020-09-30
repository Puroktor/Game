using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour {

    private float damageRate = 1f;
    private float curTimeout;
    private int a=1;
    private Unit un;
    private double replaceUp;
    public double ReplaceUp { set { replaceUp = value; }}

    private double replaceDown;
    public double ReplaceDownS { set { replaceDown = value; } }



    private void OnTriggerEnter2D(Collider2D coll)
    {
        Unit unit =coll.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            un = coll.GetComponent<Unit>();
            un.ReciveDamage();
            a = 0;
        }
    }
    void Update()
    {
        if (a == 0)
        {
            curTimeout += Time.deltaTime;
            if (curTimeout > damageRate)
            {
                curTimeout = 0;
                un.ReciveDamage();
            }
        }
        if (replaceUp > 0)
        {
            Replace();
            replaceUp= replaceUp-0.01;
        }

        if (replaceDown > 0)
        {
            ReplaceDown();
            replaceDown = replaceDown - 0.01;
        }
    }

        private void OnTriggerExit2D(Collider2D coll)
    {
        a = 1;
        curTimeout = 0f;
    }

    public void Replace()
    {
        Vector3 target = transform.position;  target.y += 1f;
        transform.position = Vector3.MoveTowards(transform.position,target,0.01f);
    }

    public void ReplaceDown()
    {
        Vector3 target = transform.position; target.y -= 1f;
        transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);
    }
       
    }


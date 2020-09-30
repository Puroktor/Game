using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public virtual void ReciveDamage()
    {
        Die();
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}

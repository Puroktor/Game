using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Character character = coll.GetComponent<Character>();
        if (character)
        {
            character.Lives++;
            Destroy(gameObject);
        }
    }
	
}

using UnityEngine;
using System.Collections;

public class Parolax : MonoBehaviour {

    [SerializeField]
    private float speed;

	
	void Update () {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * speed) % 1, 0f);
    }
}

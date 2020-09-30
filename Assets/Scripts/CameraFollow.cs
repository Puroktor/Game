using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


    public float damping = 0.8f;
    [SerializeField]
    private Transform player;


    void LateUpdate()
    {
        try
        {
            Vector3 target = player.position; target.z -= 10.0f; target.y = 0;

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
        catch { }
    }
}


	
	

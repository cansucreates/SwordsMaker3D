using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // offset from the player
    public float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position; // calculate the offset
    }

    // Update is called once per frame
    void FixedUpdate() 
    {

        Vector3 targetPosition = player.position + offset; // update the camera position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed); // smooth the camera movement




    }
}

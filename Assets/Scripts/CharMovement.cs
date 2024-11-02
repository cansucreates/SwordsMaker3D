using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float sideSpeed = 10f;

    // platform boundaries
    public float leftBound = -5f;
    public float rightBound = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        // forward movement
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardSpeed);


        //side movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float targetX = rb.position.x + horizontalInput * sideSpeed * Time.fixedDeltaTime;

        // clamp X to the boundaries
        targetX = Mathf.Clamp(targetX, leftBound, rightBound);

        rb.position = new Vector3(targetX, rb.position.y, rb.position.z);


        // rb.velocity = new Vector3(horizontalInput * sideSpeed, rb.velocity.y, rb.velocity.z); 



    }
}

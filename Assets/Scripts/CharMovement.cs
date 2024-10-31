using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float sideSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        // movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(horizontalInput * sideSpeed, rb.velocity.y, forwardSpeed); 



    }
}

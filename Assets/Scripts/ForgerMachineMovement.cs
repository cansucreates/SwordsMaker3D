using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgerMachineMovement : MonoBehaviour
{

    public Transform upperPart;
    public float moveDistance = 0.5f;
    public float moveSpeed = 2f;
    public string bucketTag = "bucket";

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool movingDown = true;


    // Start is called before the first frame update
    void Start()
    {
        if(upperPart == null)
        {
            Debug.LogError("Upper part is not assigned in the forge machine");
            return;
        }

        initialPosition = upperPart.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            MoveUpperPart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;

        // Check if the object or its parent is a bucket
        while (target != null)
        {
            if (target.CompareTag(bucketTag)) // Detect the bucket tag
            {
                Debug.Log($"Bucket detected: {target.name}");
                StartMoving(); // Trigger the forge machine
                return;
            }

            // Move up the hierarchy to check parents
            target = target.transform.parent != null ? target.transform.parent.gameObject : null;
        }

        Debug.Log($"Non-bucket object detected: {other.name}");
    }

    private void StartMoving()
    {
        isMoving = true;
        movingDown = true;
        targetPosition = initialPosition - new Vector3(0, moveDistance, 0); // down
    }

    private void MoveUpperPart()
    {
        upperPart.localPosition = Vector3.MoveTowards(upperPart.localPosition, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(upperPart.localPosition, targetPosition) < 0.01f)
        {
            if (movingDown)
            {
                // if moving down switch to moving up
                movingDown = false;
                targetPosition = initialPosition;
            }
            else
            {
                // if moving up, stop the movement
                isMoving = false;
                Debug.Log("Part movement completed");
            }
        }

    }

}

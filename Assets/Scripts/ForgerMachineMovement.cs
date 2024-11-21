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

        while (target != null)
        {
            if (target.CompareTag(bucketTag))
            {
                Debug.Log($"Bucket detected: {target.name}");
                StartMoving(); // forgerý tetikle
                return;
            }

            //hiyerarþide parent checkle
            target = target.transform.parent != null ? target.transform.parent.gameObject : null;
        }

    }

    private void StartMoving()
    {
        isMoving = true;
        movingDown = true;
        targetPosition = initialPosition - new Vector3(0, moveDistance, 0); // aþaðý
    }

    private void MoveUpperPart()
    {
        upperPart.localPosition = Vector3.MoveTowards(upperPart.localPosition, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(upperPart.localPosition, targetPosition) < 0.01f)
        {
            if (movingDown)
            {
                // eðer aþaðýysa yukarý switchle
                movingDown = false;
                targetPosition = initialPosition;
            }
            else
            {
                // eðer yukarý hareket ediyosa durdur
                isMoving = false;
            }
        }

    }

}

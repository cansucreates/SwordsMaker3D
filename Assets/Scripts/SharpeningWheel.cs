using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningWheel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bucket"))
        {
            BucketToSword bucketToSword = other.GetComponent<BucketToSword>();
            if(bucketToSword != null )
            {
                bucketToSword.CheckAndConvertBucket();
            }
        }
    }
}

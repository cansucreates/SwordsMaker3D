using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketPickup : MonoBehaviour
{
    
    private List<GameObject> pickedUpBuckets = new List<GameObject>();
    // bucket ve sword handle arasý offset
    public float initialBucketOffset = 0.5f;
    // bucketlar arasý offset
    public float subBucketOffset = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bucket"))
        {
            // bucketý ekle
            pickedUpBuckets.Add(other.gameObject);

            // colliderý disable et isKinematic yap
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;

            // parentýný sword yap
            other.transform.parent = transform;

            // bucketý konumlandýr
            PositionBucket(other.gameObject);
        }
    }

    private void PositionBucket(GameObject bucket)
    {
        int index = pickedUpBuckets.Count - 1; // listenin son elemaný indexi

        Vector3 targetPosition;

        if (index == 0)
        {
            // ilk bucketý konumlandýr
            targetPosition = transform.position + transform.forward * initialBucketOffset;
        }
        else
        {
            // bucketlar arasý offset konumlandýrma
            Vector3 previousBucketPosition = pickedUpBuckets[index - 1].transform.position;
            targetPosition = previousBucketPosition + transform.forward * subBucketOffset;
        }

        // world position set
        bucket.transform.position = targetPosition;
    }


}

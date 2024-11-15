using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketPickup : MonoBehaviour
{

    private List<GameObject> pickedUpBuckets = new List<GameObject>();
    // bucket ve sword handle arası offset
    public float initialBucketOffset = 0.5f;
    // bucketlar arası offset
    public float subBucketOffset = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bucket"))
        {
            pickedUpBuckets.Add(other.gameObject);

            // Disable collider and make kinematic
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;

            // Parent to the "PickedBuckets" holder
            Transform pickedBucketsHolder = transform.Find("PickedBuckets");
            if (pickedBucketsHolder == null)
            {
                // Create the holder if it doesn't exist
                pickedBucketsHolder = new GameObject("PickedBuckets").transform;
                pickedBucketsHolder.SetParent(transform);
            }
            other.transform.parent = pickedBucketsHolder;

            PositionBucket(other.gameObject);
        }
    }


    private void PositionBucket(GameObject bucket)
    {
        int index = pickedUpBuckets.Count - 1; // listenin son elemanı indexi

        Vector3 targetPosition;

        if (index == 0)
        {
            // ilk bucketı konumlandır
            targetPosition = transform.position + transform.forward * initialBucketOffset;
        }
        else
        {
            // bucketlar arası offset konumlandırma
            Vector3 previousBucketPosition = pickedUpBuckets[index - 1].transform.position;
            targetPosition = previousBucketPosition + transform.forward * subBucketOffset;
        }

        // world position set
        bucket.transform.position = targetPosition;
    }

}

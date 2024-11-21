using System.Collections.Generic;
using UnityEngine;

public class BucketPickup : MonoBehaviour
{
    private List<GameObject> pickedUpBuckets = new List<GameObject>();

    public float initialBucketOffset = 0.5f;
    public float subBucketOffset = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bucket"))
        {
            if (other.gameObject != null)
            {
                pickedUpBuckets.Add(other.gameObject);

                other.GetComponent<Rigidbody>().isKinematic = true;

                Transform pickedBucketsHolder = transform.Find("PickedBuckets");
                if (pickedBucketsHolder == null)
                {
                    pickedBucketsHolder = new GameObject("PickedBuckets").transform;
                    pickedBucketsHolder.SetParent(transform);
                }
                other.transform.parent = pickedBucketsHolder;

                PositionBucket(other.gameObject);
            }
        }
    }

    private void PositionBucket(GameObject bucket)
    {
        if (bucket == null)
        {
            return;
        }

        int index = pickedUpBuckets.Count - 1;

        Vector3 targetPosition;

        if (index == 0)
        {
            targetPosition = transform.position + transform.forward * initialBucketOffset;
        }
        else
        {
            Vector3 previousBucketPosition = pickedUpBuckets[index - 1].transform.position;
            targetPosition = previousBucketPosition + transform.forward * subBucketOffset;
        }

        bucket.transform.position = targetPosition;
    }

    public void RemoveBucketFromList(GameObject bucket)
    {
        if (pickedUpBuckets.Contains(bucket))
        {
            pickedUpBuckets.Remove(bucket);
        }
    }

    private void CleanupDestroyedBuckets()
    {
        pickedUpBuckets.RemoveAll(bucket => bucket == null);
    }

    private void Update()
    {
        CleanupDestroyedBuckets();
    }
}

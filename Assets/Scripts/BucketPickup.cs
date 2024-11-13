using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketPickup : MonoBehaviour
{
    
    private List<GameObject> pickedUpBuckets = new List<GameObject>();
    // bucket ve sword handle aras� offset
    public float initialBucketOffset = 0.5f;
    // bucketlar aras� offset
    public float subBucketOffset = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bucket"))
        {
            // bucket� ekle
            pickedUpBuckets.Add(other.gameObject);

            // collider� disable et isKinematic yap
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;

            // parent�n� sword yap
            other.transform.parent = transform;

            // bucket� konumland�r
            PositionBucket(other.gameObject);
        }
    }

    private void PositionBucket(GameObject bucket)
    {
        int index = pickedUpBuckets.Count - 1; // listenin son eleman� indexi

        Vector3 targetPosition;

        if (index == 0)
        {
            // ilk bucket� konumland�r
            targetPosition = transform.position + transform.forward * initialBucketOffset;
        }
        else
        {
            // bucketlar aras� offset konumland�rma
            Vector3 previousBucketPosition = pickedUpBuckets[index - 1].transform.position;
            targetPosition = previousBucketPosition + transform.forward * subBucketOffset;
        }

        // world position set
        bucket.transform.position = targetPosition;
    }


}

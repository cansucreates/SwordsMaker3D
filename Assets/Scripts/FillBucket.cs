using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

 public class FillBucket : MonoBehaviour
{

    /*

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;

        // Check if this object or its parent matches the "bucket" tag
        while (target != null)
        {
            if (target.CompareTag("bucket"))
            {
                Bucket bucket = target.GetComponent<Bucket>();
                if (bucket != null)
                {
                    Debug.Log($"Bucket script found on: {bucket.gameObject.name}");
                    bucket.FillWithLava();
                    return;
                }
                else
                {
                    Debug.LogError($"Bucket script not found on the bucket: {target.name}");
                    return;
                }
            }

            // Move up to the parent object in case the bucket is nested
            target = target.transform.parent != null ? target.transform.parent.gameObject : null;
        }

        Debug.Log($"Trigger detected with non-bucket object: {other.gameObject.name}");
    }


*/



}

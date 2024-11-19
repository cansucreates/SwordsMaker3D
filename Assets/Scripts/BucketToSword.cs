using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketToSword : MonoBehaviour
{
    public GameObject swordPartPrefab; // Prefab for the sword part
    public Transform attachmentPoint; // Point where parts attach
    public float partSpacing = 0.5f;  // Distance between parts
    public float delayBeforeAddingPart = 0.1f;

    public void CheckAndConvertBucket()
    {
        // Ensure the bucket has the BucketFill component
        BucketFill bucketFill = GetComponent<BucketFill>();
        if (bucketFill == null)
        {
            Debug.LogError($"BucketFill component is missing on {gameObject.name}");
            return;
        }

        // Check if the bucket is forged
        if (bucketFill.isForged)
        {
            StartCoroutine(AddSwordPartWithDelay());

        }
        else
        {
            Debug.Log($"Bucket {gameObject.name} was not forged. No sword part added.");
            Destroy(gameObject);
        }


    }


    private IEnumerator AddSwordPartWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeAddingPart);
        GameObject newSwordPart = Instantiate(
               swordPartPrefab,
               attachmentPoint.position,
               attachmentPoint.rotation,
               attachmentPoint // Parent to the attachment point
         );

        // Re-parent the new sword part to the sword handle
        newSwordPart.transform.SetParent(attachmentPoint.parent, true);

        // Move the attachment point forward for the next part
        attachmentPoint.position += attachmentPoint.forward * partSpacing;


        Destroy(gameObject);
    }



}

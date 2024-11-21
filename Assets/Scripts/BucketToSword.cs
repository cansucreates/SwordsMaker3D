using System.Collections;
using UnityEngine;

public class BucketToSword : MonoBehaviour
{
    public GameObject swordPartPrefab;  
    public Transform attachmentPoint;  // sword partlarýn attachlenceði nokta
    public float partSpacing = 0.5f;   // partlar arasý mesafe
    public float delayBeforeAddingPart = 0.1f;

    public SwordManager swordManager;

    public void CheckAndConvertBucket()
    {
        
        BucketFill bucketFill = GetComponent<BucketFill>();
        if (bucketFill == null)
        {
            return;
        }

        // eðer bucket forgelandýysa
        if (bucketFill.isForged)
        {
            StartCoroutine(AddSwordPartWithDelay());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator AddSwordPartWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeAddingPart);

        // attachment noktasýna yeni sword part ekleme
        GameObject newSwordPart = Instantiate(
            swordPartPrefab,
            attachmentPoint.position,
            attachmentPoint.rotation
        );

        // sword handle'ý parentla
        newSwordPart.transform.SetParent(attachmentPoint.parent);

        // attachment pointin local positionýný diðer part için deðiþtirme
        attachmentPoint.localPosition += Vector3.forward * partSpacing;

        // sword managera bildirme
        if (swordManager != null)
        {
            swordManager.RegisterSwordPart(newSwordPart);
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class BucketToSword : MonoBehaviour
{
    public GameObject swordPartPrefab;  
    public Transform attachmentPoint;  // sword partlar�n attachlence�i nokta
    public float partSpacing = 0.5f;   // partlar aras� mesafe
    public float delayBeforeAddingPart = 0.1f;

    public SwordManager swordManager;

    public void CheckAndConvertBucket()
    {
        
        BucketFill bucketFill = GetComponent<BucketFill>();
        if (bucketFill == null)
        {
            return;
        }

        // e�er bucket forgeland�ysa
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

        // attachment noktas�na yeni sword part ekleme
        GameObject newSwordPart = Instantiate(
            swordPartPrefab,
            attachmentPoint.position,
            attachmentPoint.rotation
        );

        // sword handle'� parentla
        newSwordPart.transform.SetParent(attachmentPoint.parent);

        // attachment pointin local position�n� di�er part i�in de�i�tirme
        attachmentPoint.localPosition += Vector3.forward * partSpacing;

        // sword managera bildirme
        if (swordManager != null)
        {
            swordManager.RegisterSwordPart(newSwordPart);
        }

        Destroy(gameObject);
    }
}

using UnityEngine;

public class UpgradeSelector : MonoBehaviour
{
    public SwordManager swordManager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageCollider"))
        {
            UpgradeSwordPart("Damage", other);
        }
        else if (other.CompareTag("SpeedCollider"))
        {
            UpgradeSwordPart("Speed", other);
        }
    }

    private void UpgradeSwordPart(string upgradeType, Collider other)
    {
        GameObject swordPart = swordManager.GetNextSwordPart();
        if (swordPart == null)
        {
            return;
        }

        SwordPart swordPartScript = swordPart.GetComponent<SwordPart>();
        if (swordPartScript != null)
        {
            swordPartScript.Upgrade(upgradeType);

            // upgradeledikten sonra sword partý destroyla
            Destroy(swordPart);
            Debug.Log($"Sword part upgraded to {upgradeType} and destroyed.");
        }
    }
}

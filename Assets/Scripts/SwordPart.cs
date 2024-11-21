using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPart : MonoBehaviour
{
    public string upgradeType;

    public void Upgrade(string newUpgradeType)
    {
        upgradeType = newUpgradeType;

        if (newUpgradeType == "Damage")
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (newUpgradeType == "Speed")
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        
        Destroy(gameObject);
    }


}

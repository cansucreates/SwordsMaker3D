using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    private Queue<GameObject> swordParts = new Queue<GameObject>();

    public void RegisterSwordPart(GameObject swordPart)
    {
        swordParts.Enqueue(swordPart);
    }

    public GameObject GetNextSwordPart()
    {
        if (swordParts.Count > 0)
        {
            return swordParts.Dequeue();
        }

        return null;
    }
}

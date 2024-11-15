using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{

    public GameObject steel;

    private bool isFilled = false;

    private void Start()
    {
        if (steel != null)
        {
            steel.SetActive(false);
        }
        else
        {
            Debug.LogError($"Steel object not assigned for bucket: {gameObject.name}");
        }
    }

    public void FillWithLava()
    {
        if (!isFilled && steel != null)
        {
            isFilled = true;
            Debug.Log("Activating steel for: " + gameObject.name);
            steel.SetActive(true);

            // Explicitly enable the MeshRenderer
            MeshRenderer renderer = steel.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
                Debug.Log($"MeshRenderer on {steel.name} explicitly enabled.");
            }
            else
            {
                Debug.LogError($"MeshRenderer missing on steel: {steel.name}");
            }
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MeltedSteel"))
        {
            FillWithLava();
        }
    }
}

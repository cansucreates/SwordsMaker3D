using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketFill : MonoBehaviour
{

    public GameObject steel;
    public GameObject water;

    private bool isSteelFilled = false;
    private bool isWaterFilled = false;

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

        if (water != null)
        {
            water.SetActive(false);
        }
        else
        {
            Debug.LogError($"Water object not assigned for bucket: {gameObject.name}");
        }
    }

    public void FillWithLava()
    {
        if (!isSteelFilled && steel != null)
        {
            isSteelFilled = true;
            Debug.Log("Activating steel for: " + gameObject.name);
            steel.SetActive(true);

            // Enable the MeshRenderer explicitly
            MeshRenderer steelRenderer = steel.GetComponent<MeshRenderer>();
            if (steelRenderer != null)
            {
                steelRenderer.enabled = true;
                Debug.Log($"MeshRenderer on {steel.name} explicitly enabled.");
            }
            else
            {
                Debug.LogError($"MeshRenderer missing on steel: {steel.name}");
            }
        }

    }

    public void FillWithWater()
    {
        if (isSteelFilled && !isWaterFilled && water != null)
        {
            isWaterFilled = true;
            Debug.Log("Activating water for: " + gameObject.name);
            water.SetActive(true);

            // Disable steel MeshRenderer
            MeshRenderer steelRenderer = steel.GetComponent<MeshRenderer>();
            if (steelRenderer != null)
            {
                steelRenderer.enabled = false;
                Debug.Log($"MeshRenderer on {steel.name} explicitly disabled.");
            }

            // Enable the MeshRenderer for water
            MeshRenderer waterRenderer = water.GetComponent<MeshRenderer>();
            if (waterRenderer != null)
            {
                waterRenderer.enabled = true;
                Debug.Log($"MeshRenderer on {water.name} explicitly enabled.");
            }
            else
            {
                Debug.LogError($"MeshRenderer missing on water: {water.name}");
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MeltedSteel"))
        {
            FillWithLava();
        }
        else if (other.CompareTag("Water"))
        {
            FillWithWater();
        }
    }
}

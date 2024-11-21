using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketFill : MonoBehaviour
{

    public GameObject steel;
    public GameObject water;
    public GameObject forgedSteel;

    private bool isSteelFilled = false;
    private bool isWaterFilled = false;
    public bool isForged = false;

    private void Start()
    {
        if (steel != null)
        {
            steel.SetActive(false);
        }

        if (water != null)
        {
            water.SetActive(false);
        }

        if ( forgedSteel != null)
        {
            forgedSteel.SetActive(false);
        }

    }

    public void FillWithLava()
    {
        if (!isSteelFilled && steel != null)
        {
            isSteelFilled = true;
            steel.SetActive(true);

            // meshrenderer ý aç
            MeshRenderer steelRenderer = steel.GetComponent<MeshRenderer>();
            if (steelRenderer != null)
            {
                steelRenderer.enabled = true;
            }
        }

    }

    public void FillWithWater()
    {
        if (isSteelFilled && !isWaterFilled && water != null)
        {
            isWaterFilled = true;
            water.SetActive(true);

            // steel'in mesh renderer'ini kapat
            MeshRenderer steelRenderer = steel.GetComponent<MeshRenderer>();
            if (steelRenderer != null)
            {
                steelRenderer.enabled = false;
            }

            // suyun mesh renderýný aç
            MeshRenderer waterRenderer = water.GetComponent<MeshRenderer>();
            if (waterRenderer != null)
            {
                waterRenderer.enabled = true;
            }
        }

    }

    public void ForgeComplete()
    {
        if(isSteelFilled && isWaterFilled && !isForged)
        {
            isForged = true;
            forgedSteel.SetActive(true);

            // suyun meshini kapat
            MeshRenderer waterRenderer = water.GetComponent<MeshRenderer>();
            if(waterRenderer != null)
            {
                waterRenderer.enabled = false;
            }

            MeshRenderer forgedSteelRenderer = forgedSteel.GetComponent<MeshRenderer>();
            if (forgedSteelRenderer != null)
            {
                forgedSteelRenderer.enabled = true;
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
        else if (other.CompareTag("ForgeSteel"))
        {
            ForgeComplete();
        }
    }
}

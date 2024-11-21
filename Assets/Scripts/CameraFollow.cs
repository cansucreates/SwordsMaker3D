using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // player arasý mesafe
    public float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position; // mesafeyi hesapla
    }

    // Update is called once per frame
    void FixedUpdate() 
    {

        Vector3 targetPosition = player.position + offset; // kamera pozisyonu update
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed); // kamera hareketi geçiþi




    }
}

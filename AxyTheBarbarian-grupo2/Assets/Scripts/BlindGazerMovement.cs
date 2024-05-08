using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindGazerMovement : MonoBehaviour
{
    public float distance = 3.0f;
    public float speed = 1.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        CalculateVerticalOffset();
        UpdatePosition();
    }

    void CalculateVerticalOffset()
    {
        float verticalOffset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPos + Vector3.up * verticalOffset;
    }

    void UpdatePosition()
    {
        transform.position += Vector3.right * Time.deltaTime; // Por ejemplo, mueve también en el eje X
    }
}

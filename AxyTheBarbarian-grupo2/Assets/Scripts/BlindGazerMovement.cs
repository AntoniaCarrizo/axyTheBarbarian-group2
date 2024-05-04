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
        // Calculate how much it moves on the y axis.
        // Used sin function for a better movement.
        float verticalOffset = Mathf.Sin(Time.time * speed) * distance;

        // Calculate new position based on the starting position and the added value using the sin wave.
        Vector3 newPosition = startPos + Vector3.up * verticalOffset;

        transform.position = newPosition;
    }
}
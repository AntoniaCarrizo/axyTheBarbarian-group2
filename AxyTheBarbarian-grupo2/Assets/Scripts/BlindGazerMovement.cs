using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindGazerMovement : MonoBehaviour
{
    public float distance = 3.0f;
    public float speed = 1.0f;
    private Vector3 startPos;
    private float totalVerticalDistance = 0.0f;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        float verticalOffset = direction * speed * Time.deltaTime;
        transform.position += Vector3.up * verticalOffset;

        totalVerticalDistance += Mathf.Abs(verticalOffset);

        if (totalVerticalDistance >= distance)
        {
            direction *= -1;

            totalVerticalDistance = 0.0f;
        }
    }
}

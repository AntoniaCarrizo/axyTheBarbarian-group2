using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeedSlow = 4f; //velocidad lenta
    public float moveSpeedFast = 8f; //velocidad rápida
    private bool isFastSpeed = false; //ayuda para cambiar la velocidad

    void Update()
    {
        HandleInput();
        UpdateMovement();
        UpdateColors();
    }

    void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFastSpeed = !isFastSpeed;
        }
    }

    void UpdateMovement()
    {
        float currentMoveSpeed = isFastSpeed ? moveSpeedFast : moveSpeedSlow;
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * currentMoveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void UpdateColors()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Camera.main.backgroundColor = Random.ColorHSV();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}

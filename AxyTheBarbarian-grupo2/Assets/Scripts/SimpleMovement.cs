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
        //entrada
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //cambio de velocidad
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFastSpeed = !isFastSpeed;
        }

        //dirección del movimiento
        float currentMoveSpeed = isFastSpeed ? moveSpeedFast : moveSpeedSlow;
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * currentMoveSpeed * Time.deltaTime;

        //movimiento 
        transform.Translate(movement);

        //cambiar color de fondo
        if (Input.GetKeyDown(KeyCode.X))
        {
            Camera.main.backgroundColor = Random.ColorHSV();
        }

        //cambiar color del avatar
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}


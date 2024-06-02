using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{   
    public bool isRunning = false;

    public Vector2 HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = !isRunning;
            Debug.Log(isRunning);
        }

        return new Vector2(horizontalInput, verticalInput);
    }

    public bool GetIsRunning()
    {
        return isRunning;
    }
}

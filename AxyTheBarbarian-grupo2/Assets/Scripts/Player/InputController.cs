using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{   
    private bool isFastSpeed = false;

    public (float, float) HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        CheckIsFastSpeed();

        return (horizontalInput, verticalInput);
    }

    public void CheckIsFastSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFastSpeed = !isFastSpeed;
        }
    }

    public bool GetIsFast()
    {
        return isFastSpeed;
    }
}
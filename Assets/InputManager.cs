using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject brakeButton;
    public GameObject gasButton;
    public GameObject reverseButton;

    public bool isPressingBrake()
    {
        return brakeButton.GetComponent<ButtonHoldDetection>().isButtonHeld;
    }

    public bool isPressingGas()
    {
        return gasButton.GetComponent<ButtonHoldDetection>().isButtonHeld;
    }

    public bool isPressingReverse()
    {
        return reverseButton.GetComponent<ButtonHoldDetection>().isButtonHeld;
    }

    public float steeringAngle()
    {
        // Get the accelerometer data
        Vector3 acceleration = Input.acceleration;

        // Calculate the rotation angle based on the accelerometer data
        float rotationAngle = Mathf.Atan2(acceleration.y, acceleration.x) * Mathf.Rad2Deg;
        rotationAngle += 90;

        return rotationAngle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    [SerializeField] private GameObject fan;
    public float maxRotationSpeed = 800f; // Maximum rotation speed
    public float accelerationRate = 100f; // Rate at which the fan speeds up
    public float decelerationRate = 100f; // Rate at which the fan slows down

    private bool isRotating = false;
    private float currentSpeed = 0f;

    void Update()
    {
        if (isRotating)
        {
            // Gradually increase the rotation speed up to the maximum speed
            if (currentSpeed < maxRotationSpeed)
            {
                currentSpeed += accelerationRate * Time.deltaTime;
                if (currentSpeed > maxRotationSpeed)
                    currentSpeed = maxRotationSpeed; // Cap the speed at maxRotationSpeed
            }
        }
        else
        {
            // Gradually decrease the rotation speed to zero
            if (currentSpeed > 0)
            {
                currentSpeed -= decelerationRate * Time.deltaTime;
                if (currentSpeed < 0)
                    currentSpeed = 0; // Ensure the speed doesn't go negative
            }
        }

        // Rotate the fan blades around the Y-axis
        fan.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
    }

    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}

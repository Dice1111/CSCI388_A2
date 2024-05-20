using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    [SerializeField] private GameObject fan;
    public float rotationSpeed = 100f;
    private bool isRotating = false;

    void Update()
    {
        if (isRotating)
        {
            // Rotate the fan blades around the Y-axis
            fan.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void StartRotation()
    {
        if (isRotating == false)
        {
            isRotating = true;
        }else if(isRotating == true)
        {
            isRotating = false;
        }
        
    }

   
}

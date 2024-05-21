using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AudioOnOff : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 90f;

    // Rotation vector
    public Vector3 rotationVector = new Vector3(0, 1, 0);

    // Audio on and off toggle
    public void Toggle()
    {
        // declare a variable to check if the audio is playing
        bool isPlaying = GetComponent<AudioSource>().isPlaying;
        // check if the audio is playing
        if (isPlaying)
        {
            // if it is playing, stop the audio
            GetComponent<AudioSource>()
                .Pause();
            // stop the rotation
            // transform.Rotate(0, 0, 0);
        }
        else
        {
            // if it is not playing, play the audio
            GetComponent<AudioSource>()
                .Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the y-axis at the specified speed
        if (GetComponent<AudioSource>().isPlaying)
        {
            transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);
        }
    }
}

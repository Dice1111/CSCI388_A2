using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class RecordPlayer : MonoBehaviour

{
    [SerializeField] private GameObject recordPlatter;
    public Transform platter; // Reference to the platter GameObject
    public Transform handle;  // Reference to the handle GameObject
    public AudioSource audioSource; // Reference to the AudioSource component

    private bool isPlaying = false;
    private float platterSpeed = 33.3f; // Typical speed in RPM for a record

    void Update()
    {
        if (isPlaying)
        {
            RotatePlatter();
        }
    }

    public void PlayRecord(AudioClip musicTrack)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        audioSource.clip = musicTrack;
        audioSource.Play();
        isPlaying = true;
    }

    public void StopRecord()
    {
        audioSource.Stop();
        isPlaying = false;
    }

    private void RotatePlatter()
    {
        platter.Rotate(Vector3.up, platterSpeed * Time.deltaTime * 6); // 6 degrees per second per RPM
    }

    private void OnTriggerEnter(Collider other)
    {
        // Assuming each record has a Record component with the associated AudioClip
        Record record = other.GetComponent<Record>();
        if (record != null)
        {
            PlayRecord(record.musicTrack);
        }
    }
}
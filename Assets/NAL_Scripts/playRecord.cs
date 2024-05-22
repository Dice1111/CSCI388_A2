using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class playRecord : MonoBehaviour
{
    [SerializeField] private GameObject handle;
    private XRSocketInteractor socketInteractor;
    public float rotationSpeed = 90f;
    public Vector3 rotationVector = new Vector3(0, 1, 0);
    private GameObject placedObject = null;



    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(OnSelectEntered);
        socketInteractor.selectExited.AddListener(OnSelectExited);
    }

    void OnDestroy()
    {
        socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
        socketInteractor.selectExited.RemoveListener(OnSelectExited);
    }

    // Add record
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object placed in socket");

        placedObject = args.interactableObject.transform.gameObject;
        if (placedObject != null)
        {
            AudioSource audioSource = placedObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("No AudioSource found on placed object");
            }
        }
    }

    // Remove record
    private void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("Object removed from socket");

        if (placedObject != null)
        {
            AudioSource audioSource = placedObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
            }
            else
            {
                Debug.LogWarning("No AudioSource found on removed object");
            }
            placedObject = null;
        }
    }

    
    void Update()
    {
        // Rotation
        if (placedObject != null)
        {
            AudioSource audioSource = placedObject.GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                
                transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);

                //rotate handle to 90* y-axis
                handle.transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);
            }
        }


    }
}

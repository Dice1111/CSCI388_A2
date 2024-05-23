using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class playRecord : MonoBehaviour
{
    [SerializeField] private GameObject handle;
    private XRSocketInteractor socketInteractor;
    public float rotationSpeed = 30f;
    private GameObject placedObject = null;

    public float handleRotationSpeed = 10f;
    public float handlemaxRotationAngle = 70f;
    public float handleminRotationAngle = 0f;
    private float handleCurrentRotation = 0f; 



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
        placedObject = args.interactableObject.transform.gameObject;       
    }

    // Remove record
    private void OnSelectExited(SelectExitEventArgs args)
    {
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

                //rotate handle to 90* y-axis
            if (handleCurrentRotation < handlemaxRotationAngle)
            {
                 handleCurrentRotation += handleRotationSpeed * Time.deltaTime;
                 handle.transform.Rotate(Vector3.up * handleRotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                if (!audioSource.isPlaying)
                {

                    audioSource.Play();
                }
            }
        }
        else
        {
            if (handleCurrentRotation > handleminRotationAngle)
            {
                handleCurrentRotation -= handleRotationSpeed * Time.deltaTime;
                handle.transform.Rotate(Vector3.up * -handleRotationSpeed * Time.deltaTime);
            }
        }


    }
}

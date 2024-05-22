using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSesame : MonoBehaviour
{

    [SerializeField] private GameObject bathroom_door;
    private bool doorOpen = false;
    public void openDoor()
    {
        if (doorOpen == false)
        {
            bathroom_door.transform.rotation = Quaternion.Euler(0, 360, 0);
            doorOpen = true;
            Debug.Log("yes");
        }
        else if (doorOpen == true)
        {
            bathroom_door.transform.rotation = Quaternion.Euler(0, 90, 0);
            doorOpen = false;
            Debug.Log("no");
        }

    }
}
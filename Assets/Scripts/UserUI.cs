using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserUI : MonoBehaviour
{
    [SerializeField] GameObject userUI;
    public void changeUItoCameraLocation()
    {
        userUI.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
        userUI.transform.rotation = Camera.main.transform.rotation;
        userUI.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterToggle : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterDrop;


    private bool openWater = true;


    public void ToggleWater()
    {
        if(openWater)
        {
            waterDrop.Play();
        }
        else
        {
            waterDrop.Stop();
        }

        openWater=!openWater;
    }
}

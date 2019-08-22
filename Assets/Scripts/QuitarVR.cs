using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class QuitarVR : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(LoadDevice("None"));
    }

    /*
    public void ToggleVR()
    {
       
        if (String.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
        {
            Debug.Log("cardboard");

            StartCoroutine(LoadDevice("None"));
        }
        else
        {
            Debug.Log("None");

            StartCoroutine(LoadDevice("cardboard"));
        }
    }
    */

    IEnumerator LoadDevice(string newDevice)
    {
        if (String.Compare(XRSettings.loadedDeviceName, newDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(newDevice);
            yield return null;
            XRSettings.enabled = true;

        }
    }
}
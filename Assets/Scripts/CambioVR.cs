using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class CambioVR : MonoBehaviour
{

    void Start()
    {

    }

    public void ToggleVR(/*string devi*/)
    {
    /*    if (devi != "")
        {
            Debug.Log("devi" +devi);
            StartCoroutine(LoadDevice(devi));
        }
        else { */
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
       // }
    }

    IEnumerator LoadDevice(string newDevice)
    {
        if (String.Compare(XRSettings.loadedDeviceName, newDevice, true) != 0)
        {
            Debug.Log("Cambio VR" + newDevice);
            XRSettings.LoadDeviceByName(newDevice);
            yield return null;
            XRSettings.enabled = true;

        }
    }
}
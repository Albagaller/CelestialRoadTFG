using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class CambioVR : MonoBehaviour
{
    public string devi;
     Gyro gyro;
    GameObject camara;
    public GameObject tiempo;
    public GameObject gema1;
    public GameObject gema2;
    public GameObject gema3;
    HudManage hudManage2;



    void Start()
    {
        gyro = GameObject.Find("Main Camera").GetComponent(typeof(Gyro)) as Gyro;
        camara = GameObject.Find("Main Camera");
        hudManage2 = GameObject.Find("MenuOpciones").GetComponent(typeof(HudManage)) as HudManage;

        ToggleVR();
    }

    public void ToggleVR()
    {

        if (devi != "")
        {
            StartCoroutine(LoadDevice(devi));
        }
        else { 
            if (String.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
            {

                StartCoroutine(LoadDevice("None"));
            }
            else
            {

                StartCoroutine(LoadDevice("cardboard"));
            }
        }
    }

    public void changeVR()
    {

        if (String.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
        {

            StartCoroutine(LoadDevice("None"));
            gyro.enabled = true;
            tiempo.SetActive(false);
            gema1.SetActive(false);
            gema2.SetActive(false);
            gema3.SetActive(false);


        }
        else
        {

            StartCoroutine(LoadDevice("cardboard"));
            gyro.enabled = false;
            camara.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            tiempo.SetActive(true);
            gema1.SetActive(true);
            gema2.SetActive(true);
            gema3.SetActive(true);
            hudManage2.DibujarGemas();

        }

    }

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
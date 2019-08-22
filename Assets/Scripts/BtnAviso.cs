using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAviso : MonoBehaviour
{
    public GameObject aviso;
    public Autowalk walk;
   // CambioVR cambioVR;

    // Start is called before the first frame update
    void Start()
    {
        // cambioVR = GameObject.Find("CambioVR").GetComponent(typeof(CambioVR)) as CambioVR;
       // cambioVR.ToggleVR();
        walk = GameObject.Find("Player").GetComponent<Autowalk>();
    }

    public void BtnOK()
    {
        aviso.SetActive(false);
        walk.enabled = true;
    }
}

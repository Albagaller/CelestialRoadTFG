using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System;


public class Gemas : MonoBehaviour
{
    HudManage hudManage;
    HudManage hudManage2;
    private Transform miTransform;
    public float velocidad;
    public GameObject gema;
    public GameObject audio;

    // Start is called before the first frame update
    void Start()
    {
        hudManage = GameObject.Find("HUD").GetComponent(typeof(HudManage)) as HudManage;
        hudManage2 = GameObject.Find("MenuOpciones").GetComponent(typeof(HudManage)) as HudManage;

        miTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Rotate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayClick();
        GlobalVariables.gemas++;
        hudManage.DibujarGema();
        if (GlobalVariables.vr == true){
            hudManage2.DibujarGema();
        }
        gema.SetActive(false);
    }

    void PlayClick()
    {
        //gameObject.AddComponent<AudioSource>();
        audio.GetComponent<AudioSource>().clip = Resources.Load("button_click") as AudioClip;
        audio.GetComponent<AudioSource>().volume = 1;
        audio.GetComponent<AudioSource>().Play();
    }

}

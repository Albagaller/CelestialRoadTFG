﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinLevel : MonoBehaviour
{

    GoToScene goToScene;
    Cronometro cronometro;
    public GameObject pausaMenu;

    void Start()
    {
        goToScene = GameObject.Find("GoToScene").GetComponent(typeof(GoToScene)) as GoToScene;
        cronometro = GameObject.Find("Cronometro").GetComponent(typeof(Cronometro)) as Cronometro;
    }


    void OnTriggerStay(Collider other)
    {
        cronometro.GuardarTiempo();
        goToScene.goToScene("FinNivel");
    }


}

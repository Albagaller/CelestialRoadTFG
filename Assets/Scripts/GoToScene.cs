using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{

   // CambioVR cambioVR;

    void Start()
    {

    }

    // Cambiar escena solo hay que pasar el nombre de la escena
    public void goToScene(string escena)
    {
        GlobalVariables.primera = false;

        PlayClick();
        SceneManager.LoadScene(escena);
    }

    // Cambia el nivel del juego solo hay que pasar el número del nivel
    public void NewLevel(int nivel)
    {
        if (nivel == 0)
        {
            goToScene("EscenaInicio");
        }
        else
        {
            // cambioVR = GameObject.Find("CambioVR").GetComponent(typeof(CambioVR)) as CambioVR;


            GlobalVariables.nivelActual = nivel;
            goToScene("Nivel" + nivel);
          //  cambioVR.ToggleVR();
        }
        
    }

    void PlayClick()
    {
        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().clip = Resources.Load("button_click") as AudioClip;
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().Play();
    }

}

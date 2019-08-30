using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{
    GoToScene goToScene;
    public Text textLevel;
    public Text textTiempo;
    public float tiempo;
    public GameObject[] estrellas;
    public GameObject[] objetos;


    void Start()
    {
        textLevel.text = "Nivel  " + GlobalVariables.nivelActual + " superado";
        goToScene = GameObject.Find("GoToScene").GetComponent(typeof(GoToScene)) as GoToScene;
        CalcularTiempo();
        DibujarGemas();
        CalcularValoracion();
        DesbloquearNivel();
        ClearLevel();
    }

    // Clacula y Escribe el tiempo en la pantalla de fin
    public void CalcularTiempo()
    {

        tiempo = GlobalVariables.tiempoFin;
        int mins = (int)tiempo / 60;
        int segs = (int)tiempo % 60;

        textTiempo.text = "Tiempo: " + mins.ToString().PadLeft(2, '0') + ":" + segs.ToString().PadLeft(2, '0');
    }

    //dibuja las gemas recogidas
    public void DibujarGemas()
    {
        for (int i = 0; i < GlobalVariables.gemas; i++)
        {
            objetos[i].SetActive(true);
        }
    }

    // Desbloquea el siguiente nivel y vuelve a la ventana de eleccion de niveles
    public void DesbloquearNivel()
    {

        GlobalVariables.nivelActual++;
        GlobalVariables.nivelesDesbloqueados = PlayerPrefs.GetInt("levelsUnlock");

        if (GlobalVariables.nivelesDesbloqueados <= GlobalVariables.nivelActual)
        {
            GlobalVariables.nivelesDesbloqueados = GlobalVariables.nivelActual;
            PlayerPrefs.SetInt("levelsUnlock", GlobalVariables.nivelesDesbloqueados);
        }
       
    }

    //Calcular puntuacion
    public void CalcularValoracion()
    {

        int valoracion = 0;
        
        //Calcula el número de estrellas en función del tiempo y las gemas recolectadas

        if (GlobalVariables.tiempoEstimado[GlobalVariables.nivelActual - 1] >= tiempo && GlobalVariables.gemas == 3)
        {
            valoracion = 3;
        }
        else if((GlobalVariables.tiempoEstimado[GlobalVariables.nivelActual - 1] >= tiempo && GlobalVariables.gemas < 3) || (GlobalVariables.tiempoEstimado[GlobalVariables.nivelActual - 1] < tiempo && GlobalVariables.gemas == 3))
        {
            valoracion = 2;
        }
        else
        {
            valoracion = 1;
        }

        DibujarEstrellas(valoracion);


        if (PlayerPrefs.GetInt("puntuacion" + GlobalVariables.nivelActual) < valoracion)
        {
            GlobalVariables.puntuaciones[GlobalVariables.nivelActual - 1] = valoracion;
            PlayerPrefs.SetInt("puntuacion" + GlobalVariables.nivelActual, valoracion);
        }
    }


    // Dibujar estrellas 
    public void DibujarEstrellas(int num)
    {
        for (int i = 0; i < num; i++)
        {
            estrellas[i].SetActive(true);
        }
    }


    // Dibujar estrellas 
    public void ClearLevel()
    {
        GlobalVariables.gemas = 0;
    }


    // Vuelve a la ventana de seleccion de nivel
    public void VolverAlMenu()
    {
        GlobalVariables.primera = false;
        goToScene.goToScene("MenuNiveles");
    }

    public void NextLevel()
    {
        goToScene.NewLevel(GlobalVariables.nivelActual);
    }

    public void RepeatLevel()
    {
        GlobalVariables.nivelActual--;
        goToScene.NewLevel(GlobalVariables.nivelActual);
    }
   
}



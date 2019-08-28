using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVariables : MonoBehaviour
{ 
    //sonido del juego
    public static bool mute = false;
    //Unlock levels
    public static int nivelActual = 1;
    public static int nivelesDesbloqueados = 1;

    // Puntuaciones de los niveles
    public static int[] puntuaciones = new int[6];

    // Tiempo estimado para cada nivel
    public static int[] tiempoEstimado = new int[] { 100, 80, 90, 100, 110, 160 };

    // para la puntuación del nivel
    public static float StartTimeNivel;
    public static float tiempoFin;
    public static int gemas = 0;

    //Pausa
    public static bool GameIsPause = false;

    public static bool GameIni = true;


}

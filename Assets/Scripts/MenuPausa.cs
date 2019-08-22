using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    GoToScene goToScene;
    Cronometro cronometro;
    public GameObject pausaMenu;
    public Autowalk walk;
    public Text textLevel;
    public Text txtTiempo;
    public GameObject[] objetos;
    public Camera cam;
    private Transform miTransform;

    void Start()
    {
        goToScene = GameObject.Find("GoToScene").GetComponent(typeof(GoToScene)) as GoToScene;
        cronometro = GameObject.Find("Cronometro").GetComponent(typeof(Cronometro)) as Cronometro;

        textLevel.text = "Nivel " + GlobalVariables.nivelActual;
        walk = GameObject.Find("Player").GetComponent<Autowalk>();

        //cuando se ponga en boton borrar
        GlobalVariables.GameIsPause = true;
        walk.enabled = false;
        valoresPanel();

    }

    // Vuelve a la ventana de seleccion de nivel
    public void VolverAlMenu()
    {
        GlobalVariables.GameIsPause = false;
        goToScene.goToScene("MenuNiveles");
    }

    public void RepeatLevel()
    {
        GlobalVariables.GameIsPause = false;
        goToScene.NewLevel(GlobalVariables.nivelActual);
        GlobalVariables.gemas = 0;
    }

    public void Resume()
    {
        pausaMenu.SetActive(false);
        GlobalVariables.GameIsPause = false;
        walk.enabled=true;
    }

    public void Pause()
    {
        GlobalVariables.GameIsPause = true;
        
        valoresPanel();
        pausaMenu.SetActive(true);
        walk.enabled = false;
        textLevel.text = "Nivel " + GlobalVariables.nivelActual;

    }

    // Clacula y Escribe el tiempo en la pantalla de fin
    void CalcularTiempo()
    {

        float tiempo = GlobalVariables.tiempoFin;
        int mins = (int)tiempo / 60;
        int segs = (int)tiempo % 60;

        txtTiempo.text = "Tiempo: " + mins.ToString().PadLeft(2, '0') + ":" + segs.ToString().PadLeft(2, '0');
    }

    //dibuja las gemas recogidas
    void DibujarGemas()
    {
        for (int i = 0; i < GlobalVariables.gemas; i++)
        {
            objetos[i].SetActive(true);
        }
    }

    void ColocarPanel()
    {
        miTransform = GetComponent<Transform>();
        miTransform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        miTransform.position = cam.transform.position;
    }

    void guardarTiempo()
    {
        cronometro = GameObject.Find("Cronometro").GetComponent(typeof(Cronometro)) as Cronometro;
        cronometro.GuardarTiempo();

    }

    void valoresPanel()
    {
        guardarTiempo();
        DibujarGemas();
        ColocarPanel();
        CalcularTiempo();
    }

}

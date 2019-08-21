using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    public int level;
    public Image candado;
    public Text texto;
    public GameObject[] estrellas;

    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.SetInt("levelsUnlock", 1);
        if (PlayerPrefs.GetInt("levelsUnlock")>0)
        {
            GlobalVariables.nivelesDesbloqueados = PlayerPrefs.GetInt("levelsUnlock");
        }

        if (GlobalVariables.nivelesDesbloqueados >= level)
        {
            LevelUnlocked();
        }
        else
        {
            LevelLocked();
        }


        if (PlayerPrefs.GetInt("puntuacion" + level)>0)
        {
            GlobalVariables.puntuaciones[level -1] = PlayerPrefs.GetInt("puntuacion" + level);
            DibujarEstrellas(GlobalVariables.puntuaciones[level - 1]);
            
        }
    }

    // Nivel bloqueado
    void LevelLocked()
    {
        GetComponent<Button>().interactable = false;
        candado.enabled = true;
        texto.enabled = false;
    }

    //Desbloquear nivel
    void LevelUnlocked()
    {
       // Debug.Log("CCCCCCCCC" + level);
        GetComponent<Button>().interactable = true;
        candado.enabled = false;
        texto.enabled = true;
    }

    // Dibujar estrellas 
    public void DibujarEstrellas(int num)
    {
        for (int i = 0; i < num; i++)
        {
            estrellas[i].SetActive(true);
        }
    }
}

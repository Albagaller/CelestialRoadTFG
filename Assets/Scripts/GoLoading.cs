using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLoading : MonoBehaviour
{
    public GameObject loading;
    public int lvl;



    public void saveNumLevel()
    {
        GlobalVariables.nivelActual = lvl;
        loading.SetActive(true);
    }
}

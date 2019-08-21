using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManage : MonoBehaviour
{
    public GameObject[] objetos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DibujarGemas()
    {
        for (int i = 0; i < GlobalVariables.gemas; i++)
        {
            objetos[i].SetActive(true);
        }
    }

    public void DibujarGema()
    {
        objetos[GlobalVariables.gemas - 1].SetActive(true);
        
    }

}

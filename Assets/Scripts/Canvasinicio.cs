using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasinicio : MonoBehaviour
{

    public GameObject canvas1;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalVariables.primera)
        {
            canvas1.SetActive(true);
        }
        else
        {
            canvas1.SetActive(false);

        }

        GlobalVariables.primera = true;
    }

}

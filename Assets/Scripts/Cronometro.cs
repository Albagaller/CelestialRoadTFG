using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public Text txtTiempo;
    public Text txtTiempo2;
    private float  StartTime;
    private float TimerControl;

    // Start is called before the first frame update
    void Start()
    {
        txtTiempo.text = "00:00";
        StartTime = Time.time;
        GlobalVariables.StartTimeNivel = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalVariables.GameIsPause)
        {
            TimerControl += 1 * Time.deltaTime;

            // TimerControl = Time.time - StartTime;
            int mins = (int)TimerControl / 60;
            int segs = (int)TimerControl % 60;

            txtTiempo.text = "" + mins.ToString().PadLeft(2, '0') + ":" + segs.ToString().PadLeft(2, '0');
            txtTiempo2.text = "" + mins.ToString().PadLeft(2, '0') + ":" + segs.ToString().PadLeft(2, '0');

        }
    }

    public void GuardarTiempo()
    {
        GlobalVariables.tiempoFin = TimerControl;
    }
}

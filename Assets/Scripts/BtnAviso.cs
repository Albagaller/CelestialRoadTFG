using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAviso : MonoBehaviour
{
    public GameObject aviso;
    public Autowalk walk;

    // Start is called before the first frame update
    void Start()
    {
        walk = GameObject.Find("Player").GetComponent<Autowalk>();
    }

    public void BtnOK()
    {
        aviso.SetActive(false);
        walk.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gemas : MonoBehaviour
{
    HudManage hudManage;
    private Transform miTransform;
    public float velocidad;
    public GameObject gema;

    // Start is called before the first frame update
    void Start()
    {
        hudManage = GameObject.Find("HUD").GetComponent(typeof(HudManage)) as HudManage;
        miTransform = GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Rotate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        GlobalVariables.gemas++;
        gema.SetActive(false);
        hudManage.DibujarGema();
    }
}

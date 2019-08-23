using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaCarga : MonoBehaviour
{

    private Transform miTransform;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        miTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Rotate(Vector3.forward * velocidad * Time.deltaTime);

    }
}

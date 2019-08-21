using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBtns : MonoBehaviour
{

    public GameObject player;
    public Camera cam;
    private Transform miTransform;


    // Start is called before the first frame update
    void Start()
    {
        miTransform = GetComponent<Transform>();
        miTransform.position = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        miTransform.position = cam.transform.position;
    }
}

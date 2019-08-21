﻿using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour
{
    private const int RIGHT_ANGLE = 90;

    // This variable determinates if the player will move or not 
    private bool isWalking = false;

    Transform mainCamera = null;
    CharacterController cam;

    //This is the variable for the player speed
    [Tooltip("With this speed the player will move.")]
    public float speed;

    [Tooltip("Activate this checkbox if the player shall move when the Cardboard trigger is pulled.")]
    public bool walkWhenTriggered;

    [Tooltip("Activate this checkbox if the player shall move when he looks below the threshold.")]
    public bool walkWhenLookDown;

    [Tooltip("This has to be an angle from 0° to 90°")]
    public double thresholdAngle;

    [Tooltip("Activate this Checkbox if you want to freeze the y-coordiante for the player. " +
             "For example in the case of you have no collider attached to your CardboardMain-GameObject" +
             "and you want to stay in a fixed level.")]
    public bool freezeYPosition;

    [Tooltip("This is the fixed y-coordinate.")]
    public float yOffset;

    void Start()
    {
        mainCamera = Camera.main.transform;
        cam = gameObject.GetComponent<CharacterController>();

    }

    void Update()
    {
        // Walk when the Cardboard Trigger is used 
        if (walkWhenTriggered && !walkWhenLookDown && !isWalking && Input.GetButtonDown("Fire1"))
        {
            isWalking = true;
        }
        else if (walkWhenTriggered && !walkWhenLookDown && isWalking && Input.GetButtonDown("Fire1"))
        {
            isWalking = false;
        }

        // Walk when player looks below the threshold angle 
        if (walkWhenLookDown && !walkWhenTriggered && !isWalking &&
            mainCamera.transform.eulerAngles.x >= thresholdAngle &&
            mainCamera.transform.eulerAngles.x <= RIGHT_ANGLE)
        {
            isWalking = true;
        }
        else if (walkWhenLookDown && !walkWhenTriggered && isWalking &&
                 (mainCamera.transform.eulerAngles.x <= thresholdAngle ||
                 mainCamera.transform.eulerAngles.x >= RIGHT_ANGLE))
        {
            isWalking = false;
        }

        // Walk when the Cardboard trigger is used and the player looks down below the threshold angle
        if (walkWhenLookDown && walkWhenTriggered && !isWalking &&
            mainCamera.transform.eulerAngles.x >= thresholdAngle &&
            Input.GetButtonDown("Fire1") &&
            mainCamera.transform.eulerAngles.x <= RIGHT_ANGLE)
        {
            isWalking = true;
        }
        else if (walkWhenLookDown && walkWhenTriggered && isWalking &&
                 mainCamera.transform.eulerAngles.x >= thresholdAngle &&
                 (Input.GetButtonDown("Fire1") ||
                 mainCamera.transform.eulerAngles.x >= RIGHT_ANGLE))
        {
            isWalking = false;
        }

        if (isWalking)
        {
            Vector3 direction = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            // transform.Translate(rotation * direction);
            cam.Move(rotation * direction);
        }

        if (freezeYPosition)
        {
            transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
        }
    }
}
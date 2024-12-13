using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Elizeo_PlayerCam : MonoBehaviour
{
    public float xSens;
    public float ySens;

    public Transform playerOri;

    private float xRot;
    private float yRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Rotation for the mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //Rotation for cam and orientation
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        playerOri.rotation = Quaternion.Euler(0, yRot, 0);
    }
}


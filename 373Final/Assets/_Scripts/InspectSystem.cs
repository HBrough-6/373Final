using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectSystem : MonoBehaviour
{
    [SerializeField] private Transform objectToInspect;

    public float rotationSpeed = 100f;

    private Vector3 previousMousePosition;

    private bool inspecting = true;

    // Update is called once per frame
    void Update()
    {
        if (inspecting) Inspect();
    }

    private void Inspect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMousePosition = Input.mousePosition - previousMousePosition;
            float rotationX = deltaMousePosition.y * rotationSpeed * Time.deltaTime;
            float rotationY = -deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            objectToInspect.rotation = rotation * objectToInspect.rotation;

            previousMousePosition = Input.mousePosition;
        }
    }

    public void StartInspecting(GameObject obj)
    {
        inspecting = true;
        
    }
}

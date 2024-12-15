using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainRotation : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Speed of the rotation around the Y-axis (degrees per second). Positive values for clockwise, negative for counterclockwise.")]
    public float rotationSpeed = 30f;

    [Header("Direction Control")]
    [Tooltip("Check this box to reverse the rotation direction.")]
    public bool reverseDirection = false;

    private bool hasPower = false;

    private void Update()
    {
        // Adjust rotation speed based on the reverseDirection checkbox
        if (hasPower)
        {
            float adjustedSpeed = reverseDirection ? -rotationSpeed : rotationSpeed;

            // Lock the object to only rotate around the Y-axis
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + adjustedSpeed * Time.deltaTime, 0);
        }
    }

    public void PowerOn()
    {
        hasPower = true;
    }
}

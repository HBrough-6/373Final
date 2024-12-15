using UnityEngine;

public class CloseDoorDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<FirstWheelDoorManager>().CloseDoor();
        }
    }
}

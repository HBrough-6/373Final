using UnityEngine;

public class InspectSystem : MonoBehaviour
{
    [SerializeField] private Transform objectToInspect;
    [SerializeField] private InspectableObject objectHandler;
    [SerializeField] private Camera inspectCamera;


    public float rotationSpeed = 100f;

    private Vector3 previousMousePosition;

    private bool inspecting = false;

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

    public void StartInspecting(GameObject objToInspect, InspectableObject currentObject)
    {
        inspecting = true;
        objectToInspect = objToInspect.transform;
        objectHandler = currentObject;
        transform.GetChild(0).gameObject.SetActive(true);
        inspectCamera.gameObject.SetActive(true);
    }

    public void StopInspecting()
    {
        inspecting = false;
        Destroy(objectToInspect.gameObject);
        StartCoroutine(objectHandler.UIDisappearDelay());
        objectToInspect = null;
        objectHandler = null;
        // set the UI inactive
        transform.GetChild(0).gameObject.SetActive(false);
        inspectCamera.gameObject.SetActive(false);


    }
}

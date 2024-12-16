using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InspectSystem : MonoBehaviour
{
    [SerializeField] private Transform objectToInspect;
    [SerializeField] private InspectableObject objectHandler;
    [SerializeField] private Camera inspectCamera;
    private Transform objectSpawnPoint;

    public static InspectSystem Instance;

    public float rotationSpeed = 100f;

    private Vector3 previousMousePosition;

    private bool inspecting = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        objectSpawnPoint = inspectCamera.transform.GetChild(0).transform;
    }

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

    public void StartInspecting(GameObject inspectPrefab, InspectableObject currentObject)
    {
        //PlayerInventory.Instance.gameObject.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
        inspecting = true;
        GameObject objToInspect = Instantiate(inspectPrefab, objectSpawnPoint.position, objectSpawnPoint.rotation);
        objectToInspect = objToInspect.transform;
        objectHandler = currentObject;
        transform.GetChild(0).gameObject.SetActive(true);
        inspectCamera.gameObject.SetActive(true);
    }

    public void StopInspecting()
    {
        inspecting = false;
        Destroy(objectToInspect.gameObject);
        objectHandler.UIDisappearDelay();
        objectToInspect = null;
        objectHandler = null;
        // set the UI inactive
        transform.GetChild(0).gameObject.SetActive(false);
        inspectCamera.gameObject.SetActive(false);
        //PlayerInventory.Instance.gameObject.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);


    }
}

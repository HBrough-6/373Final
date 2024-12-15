using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InspectableObject : Interactable
{
    [SerializeField] private GameObject ObjectPrefab;
    [SerializeField] private GameObject inspectCamPos;
    private InspectSystem inspectSystem;
    private bool inspecting = false;

    [SerializeField] private bool canInspectMoreThanOnce = true;

    private void Awake()
    {
        inspectSystem = InspectSystem.Instance;
    }

    public override void Activate()
    {

        UIAppearDelay();
    }

    public void Inspect()
    {
        Debug.Log("2");
        // start inpecting
<<<<<<< Updated upstream
        inspectSystem.StartInspecting(ObjectPrefab, gameObject.GetComponent<InspectableObject>());
=======
        if (ObjectPrefab)
            Debug.Log("Object");
        if (this == null)
            Debug.Log("This");
        inspectSystem.StartInspecting(ObjectPrefab, GetComponent<InspectableObject>());
>>>>>>> Stashed changes
    }

    public void ToggleInspectCam()
    {
        inspecting = !inspecting;
        CutCam.position = inspectCamPos.transform.position;
        CutCam.rotation = inspectCamPos.transform.rotation;
        CutCam.gameObject.SetActive(inspecting);
    }

    private void UIAppearDelay()
    {
        Debug.Log("1");
        ToggleInspectCam();
        Debug.Log("2");

        ToggleCanBeInteractedWith();
        Debug.Log("3");

        player.GetComponent<FirstPersonController>().ToggleMovement();
        Debug.Log("4");
        PlayerInteraction.Instance.ToggleInteraction();
        Debug.Log("5");

        player.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
        Debug.Log("6");

        Inspect();
        Debug.Log("1");

    }

    public void UIDisappearDelay()
    {
        ToggleInspectCam();
        player.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
        PlayerInteraction.Instance.ToggleInteraction();
        player.GetComponent<FirstPersonController>().ToggleMovement();

        if (!canInspectMoreThanOnce)
        {
            player.ClearInteraction();
            GunController.Instance.EnableGun();
        }
    }
}

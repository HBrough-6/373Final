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
        // start inpecting
        inspectSystem.StartInspecting(ObjectPrefab, this);
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
        ToggleInspectCam();
        ToggleCanBeInteractedWith();
        player.GetComponent<FirstPersonController>().ToggleMovement();
        PlayerInteraction.Instance.ToggleInteraction();

        player.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);

        Inspect();
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

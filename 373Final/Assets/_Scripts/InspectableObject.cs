using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InspectableObject : Interactable
{
    [SerializeField] private GameObject ObjectPrefab;
    [SerializeField] private GameObject inspectCam;
    [SerializeField] private Transform objectSpawnPoint;
    [SerializeField] private InspectSystem inspectSystem;
    [SerializeField] private InspectableObject imBegging;
    private bool inspecting = false;

    public override void Activate()
    {

        UIAppearDelay();
    }

    public void Inspect()
    {
        // start inpecting
        GameObject temp = Instantiate(ObjectPrefab, objectSpawnPoint.position, objectSpawnPoint.rotation);
        inspectSystem.StartInspecting(temp, this);
    }

    public void ToggleInspectCam()
    {
        inspecting = !inspecting;
        inspectCam.SetActive(inspecting);
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
        ToggleCanBeInteractedWith();
    }
}

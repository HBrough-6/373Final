using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InspectableObject : Interactable
{
    [SerializeField] private GameObject ObjectPrefab;
    [SerializeField] private GameObject CutCam;
    [SerializeField] private GameObject inspectCamPos;
    [SerializeField] private Transform objectSpawnPoint;
    [SerializeField] private InspectSystem inspectSystem;
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
        CutCam.transform.position = inspectCamPos.transform.position;
        CutCam.transform.rotation = inspectCamPos.transform.rotation;
        CutCam.SetActive(inspecting);
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

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

        StartCoroutine(UIAppearDelay());
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

    private IEnumerator UIAppearDelay()
    {
        ToggleInspectCam();
        ToggleCanBeInteractedWith();
        player.GetComponent<FirstPersonController>().ToggleMovement();
        yield return new WaitForSeconds(2.2f);

        player.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);

        Inspect();
    }

    public IEnumerator UIDisappearDelay()
    {
        ToggleInspectCam();
        player.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
        yield return new WaitForSeconds(2.2f);
        player.GetComponent<PlayerInteraction>().ToggleInteraction();
        player.GetComponent<FirstPersonController>().ToggleMovement();
        ToggleCanBeInteractedWith();
    }
}

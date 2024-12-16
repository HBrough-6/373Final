using UnityEngine;
using UnityEngine.UI;

// Created By Brough, Heath
// Modified 11/4/2024
// Parent script for interactables

public class Interactable : MonoBehaviour
{
    [SerializeField] private Image interactionIcon;

    [SerializeField] protected bool canBeInteractedWith = true;

    [SerializeField] private GameObject interactableText;

    protected Transform CutCam;
    protected Transform BlendCam;

    protected PlayerInteraction player;



    public virtual void Start()
    {
        player = PlayerInteraction.Instance;
        CutCam = CutCamSingleton.Instance.transform;
        BlendCam = BlendCamSingleton.Instance.transform;
    }

    // virtual function for children to override
    public virtual void Activate()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        // once player steps inside of the interaction radius, and the object can be interacted with
        // load the interaction to the player
        if (collision.CompareTag("Player") && canBeInteractedWith)
        {
            player.SetInteraction(Activate);
            SetInteractiveIcon(true);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        // once the player steps outside of the interaction radius, clear the current interaction
        if (collision.CompareTag("Player") && canBeInteractedWith)
        {
            SetInteractiveIcon(false);
            player.ClearInteraction();
        }
    }

    protected void ToggleCanBeInteractedWith()
    {
        canBeInteractedWith = !canBeInteractedWith;
        interactableText.SetActive(canBeInteractedWith);
    }

    public void SetInteractiveIcon(bool status)
    {
        interactableText.SetActive(status);
    }
}

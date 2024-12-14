using UnityEngine;

public class VIPDoor : Interactable
{

    private void Awake()
    {
        ToggleCanBeInteractedWith();
    }
    public void Unlock()
    {
        ToggleCanBeInteractedWith();
    }
    public void OpenDoor()
    {
        // play opening animation
        gameObject.GetComponent<Animator>().SetBool("Unlocked", true);
        ToggleCanBeInteractedWith();
    }

    public override void Activate()
    {
        OpenDoor();
    }
}

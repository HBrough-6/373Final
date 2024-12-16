using UnityEngine;

public class VIPDoor : Interactable
{

    private bool open = false;

    [SerializeField] private AudioClip DoorOpen;

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
        open = !open;
        gameObject.GetComponent<Animator>().SetBool("Open", true);
        ToggleCanBeInteractedWith();
        GetComponent<AudioSource>().PlayOneShot(DoorOpen);
    }

    public override void Activate()
    {
        OpenDoor();
    }
}

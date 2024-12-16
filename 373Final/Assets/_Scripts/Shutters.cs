using UnityEngine;

public class Shutters : Interactable
{
    private Animator animator;

    [SerializeField] private AudioClip ShutterOpen;
    [SerializeField] private GameObject InspectableRegister;


    private void Awake()
    {
        ToggleCanBeInteractedWith();
        animator = GetComponent<Animator>();
    }

    public void PowerUp()
    {
        ToggleCanBeInteractedWith();
        // lightParent.setActive(true);
    }

    public override void Activate()
    {
        animator.SetBool("Open", true);
        ToggleCanBeInteractedWith();
        GetComponent<AudioSource>().PlayOneShot(ShutterOpen);
    }

    public void StopShutterSound()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void ActivateCashRegister()
    {
        InspectableRegister.SetActive(true);
    }
}

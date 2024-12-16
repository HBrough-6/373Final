using UnityEngine;

public class BasicDoor : Interactable
{
    private Animator animator;

    [SerializeField] private AudioClip DoorOpen;
    [SerializeField] private AudioClip DoorClose;

    private bool open = false;

    [SerializeField] private bool needsKey = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Activate()
    {
        GetComponent<AudioSource>().Stop();

        open = !open;
        animator.SetBool("Open", open);
        if (open)
        {
            GetComponent<AudioSource>().PlayOneShot(DoorOpen);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(DoorClose);

        }
    }


}

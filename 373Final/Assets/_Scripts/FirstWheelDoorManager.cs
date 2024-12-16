using System.Collections;
using UnityEngine;

public class FirstWheelDoorManager : Interactable
{
    private Animator animator;

    [SerializeField] private AudioClip ElevatorSound;
    [SerializeField] private AudioClip ElevatorDoorOpen;

    private bool open = false;
    [SerializeField] private int unlockLoops = 3;

    [SerializeField] private bool IsFirstDoor = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Activate()
    {
        animator.SetBool("Open", true);
        ToggleCanBeInteractedWith();
        StartCoroutine(Unlocking());
        GetComponent<AudioSource>().PlayOneShot(ElevatorSound);
    }

    private IEnumerator Unlocking()
    {
        yield return new WaitForSeconds(2 * unlockLoops);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(ElevatorDoorOpen);
        animator.SetBool("Unlocked", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
}
using System.Collections;
using UnityEngine;

public class FirstWheelDoorManager : Interactable
{
    private Animator animator;

    private bool open = false;
    [SerializeField] private int unlockLoops = 3;

    [SerializeField] private bool needsKey = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public override void Activate()
    {
        animator.SetBool("Open", true);
        ToggleCanBeInteractedWith();
        StartCoroutine(Unlocking());

    }

    private IEnumerator Unlocking()
    {
        yield return new WaitForSeconds(2 * unlockLoops);
        animator.SetBool("Unlocked", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
}
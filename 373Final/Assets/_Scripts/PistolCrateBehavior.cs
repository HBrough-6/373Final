using UnityEngine;

public class PistolCrateBehavior : Interactable
{
    private Animator animator;
    private bool opened = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Activate()
    {
        animator.SetBool("Open", true);
        animator.SetBool("PistolRise", true);
        ToggleCanBeInteractedWith();
        opened = false;
    }

    public void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Open", false);
            animator.SetBool("PistolRise", false);
            if (opened)
            {
                canBeInteractedWith = false;
            }
        }
    }
}

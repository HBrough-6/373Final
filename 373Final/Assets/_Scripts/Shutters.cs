using UnityEngine;

public class Shutters : Interactable
{
    private Animator animator;
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
    }
}

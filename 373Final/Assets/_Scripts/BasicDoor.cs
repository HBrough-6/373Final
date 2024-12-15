using UnityEngine;

public class BasicDoor : Interactable
{
    private Animator animator;

    private bool open = false;

    [SerializeField] private bool needsKey = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Activate()
    {
        open = !open;
        animator.SetBool("Open", open);

    }


}

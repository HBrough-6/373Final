using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Image interactionIcon;

    [SerializeField] protected bool canBeInteractedWith = true;
    
    // virtual function for children to override
    public virtual void Activate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // once player steps inside of the interaction radius, and the object can be interacted with
        // load the interaction to the player
        if (collision.CompareTag("Player") && canBeInteractedWith)
        {
            collision.transform.GetComponent<PlayerInteraction>().SetInteraction(Activate);
            ToggleInteractiveIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // once the player steps outside of the interaction radius, clear the current interaction
        if (collision.CompareTag("Player") && canBeInteractedWith)
        {
            ToggleInteractiveIcon();
            collision.transform.GetComponent<PlayerInteraction>().ClearInteraction();
        }
    }

    protected void ToggleCanBeInteractedWith()
    {
        canBeInteractedWith = !canBeInteractedWith;
    }

    public void ToggleInteractiveIcon()
    {

    }
}

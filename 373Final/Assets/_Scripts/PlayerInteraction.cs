using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public delegate void InteractionDelegate();
    InteractionDelegate interaction;

    // loads the current interaction functionality to the player - interactable nearby
    public void SetInteraction(InteractionDelegate interactionDelegate)
    {
        Debug.Log("set");
        interaction = interactionDelegate;
    }

    // clears the current interaction functionality - no interactable nearby
    public void ClearInteraction()
    {
        Debug.Log("reset");
        interaction = null;
    }

    // if there is an interactable nearby, activate it on press of the key associated with interaction
    public void UseInteraction(InputAction.CallbackContext context)
    {
        if (interaction != null && context.started)
        {
            interaction();
        }
    }
}

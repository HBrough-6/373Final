using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public delegate void InteractionDelegate();
    private InteractionDelegate interaction;
    private bool locked = false;

    public static PlayerInteraction Instance;

    private bool hasFirstCoin = false;

    public bool HasFirstCoin
    {
        get { return hasFirstCoin; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }


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

    public void ToggleInteraction()
    {
        locked = !locked;
    }

    // if there is an interactable nearby, activate it on press of the key associated with interaction
    public void UseInteraction(InputAction.CallbackContext context)
    {
        if (interaction != null && context.started && !locked)
        {
            interaction();

        }
    }

    public void GainFirstCoin()
    {
        hasFirstCoin = true;
    }
}

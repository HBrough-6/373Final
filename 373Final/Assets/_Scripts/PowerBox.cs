using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerBox : Interactable
{
    // tells if the box has been activated
    [SerializeField] private bool activated = false;
    // list that holds all of the objects
    List<ObjectToBeActivated> objects = new List<ObjectToBeActivated>();
    [SerializeField] private Animator lever;

    // adds an object to the list of things to be activated
    public void AddMachineToList(ObjectToBeActivated obj)
    {
        objects.Add(obj);
    }

    // activate each object in the list
    public override void Activate()
    {
        Debug.Log("power");
        if (!activated)
        {
            Debug.Log("inner");
            FlipLever();
        }

    }



    private void FlipLever()
    {
        lever.SetBool("Flip", true);
        // check when the animation is over

        activated = true;
        for (int i = 0; i < objects.Count(); i++)
        {
            objects[i].TurnOn();
        }
        ToggleCanBeInteractedWith();
    }
}

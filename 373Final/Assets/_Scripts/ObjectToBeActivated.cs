using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PlayerInteraction;

public class ObjectToBeActivated : MonoBehaviour
{
    [SerializeField] private PowerBox powerBox;
    [SerializeField] private UnityEvent TurnOnAction;


    private void Start()
    {
        powerBox.AddMachineToList(this);
    }
    public void TurnOn()
    {
        if (TurnOnAction != null)
        {
            TurnOnAction?.Invoke();
            Debug.Log("weeee");
        }
        else Debug.Log("You forgot to assign the turn on function");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour
{
    [SerializeField] private GameObject LightParent;
    public void PowerOn()
    {
        LightParent.SetActive(true);
    }
}

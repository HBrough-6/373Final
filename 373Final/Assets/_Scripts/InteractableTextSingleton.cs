using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTextSingleton : MonoBehaviour
{

    public static InteractableTextSingleton Instance;

    public GameObject container;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        container = transform.GetChild(0).gameObject;
    }
}

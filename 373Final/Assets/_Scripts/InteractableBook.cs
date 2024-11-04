using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created By Brough, Heath
// Modified 11/4/2024
// Parent script for interactables

public class InteractableBook : Interactable
{
    [SerializeField] public string[] bookText;
    [SerializeField] private AudioClip OpenBookSound;
    [SerializeField] private AudioClip CloseBookSound;
    [SerializeField] private Camera BookViewCamera;
    [SerializeField] private BookUI BookUI;


    public override void Activate()
    {
        OpenBook();
    }

    private void OpenBook()
    {
        ToggleCanBeInteractedWith();
        BookUI.ActivateBook(gameObject);
    }

    public void CloseBook()
    {
        ToggleCanBeInteractedWith();
    }

    public void LookAtBook()
    {

    }

    private void OnGUI()
    {
        if (GUILayout.Button("HI"))
        {
            Activate();
        }
    }
}

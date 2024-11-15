using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField] private GameObject BookView;

    private bool BookCamActive = false;

    public override void Activate()
    {
        ToggleBookCam();
        StartCoroutine(UIDisplayDelay());
    }

    private void OpenBook()
    {
        ToggleCanBeInteractedWith();
        BookUI.ActivateBook(gameObject);
    }

    public void CloseBook()
    {
        ToggleCanBeInteractedWith();
        ToggleBookCam();
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

    private void ToggleBookCam()
    {
        BookCamActive = !BookCamActive;
        BookView.SetActive(BookCamActive);
    }

    private IEnumerator UIDisplayDelay()
    {
        yield return new WaitForSeconds(2.2f);
        OpenBook();
    }
}

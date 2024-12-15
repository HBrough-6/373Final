using System.Collections;
using UnityEngine;

// Created By Brough, Heath
// Modified 11/4/2024
// Parent script for interactables

public class InteractableBook : Interactable
{
    [SerializeField] public string[] bookText;
    [SerializeField] private AudioClip OpenBookSound;
    [SerializeField] private AudioClip CloseBookSound;
    [SerializeField] private BookUI BookUI;
    [SerializeField] private Transform BookView;

    private bool BookCamActive = false;

    public override void Activate()
    {
        ToggleBookCam();
        StartCoroutine(UIAppearDelay());
    }

    private void OpenBook()
    {
        ToggleCanBeInteractedWith();
        BookUI.ActivateBook(gameObject);
    }

    public void CloseBook()
    {
        StartCoroutine(UIDisappearDelay());
    }

    private void ToggleBookCam()
    {
        // set the camera active
        BookCamActive = !BookCamActive;
        // change the position of the camera to match the book view if you are turning on the camera
        BlendCam.position = BookView.position;
        BlendCam.rotation = BookView.rotation;
        // change the status of the camera
        BlendCam.gameObject.SetActive(!BlendCam.gameObject.activeInHierarchy);
    }

    private IEnumerator UIAppearDelay()
    {
        BookUI.FirstPersonController.ToggleMovement();
        PlayerInteraction.Instance.ToggleInteraction();
        yield return new WaitForSeconds(2.2f);
        BookUI.FirstPersonController.m_MouseLook.SetCursorLock(false);
        OpenBook();
    }

    private IEnumerator UIDisappearDelay()
    {
        ToggleBookCam();
        BookUI.FirstPersonController.m_MouseLook.SetCursorLock(true);
        yield return new WaitForSeconds(2.2f);
        PlayerInteraction.Instance.ToggleInteraction();
        BookUI.FirstPersonController.ToggleMovement();
        ToggleCanBeInteractedWith();
    }
}

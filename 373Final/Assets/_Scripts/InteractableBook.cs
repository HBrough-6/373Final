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
    [SerializeField] private Camera BookViewCamera;
    [SerializeField] private BookUI BookUI;
    [SerializeField] private GameObject BookView;

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
        BookCamActive = !BookCamActive;
        BookView.SetActive(BookCamActive);
    }

    private IEnumerator UIAppearDelay()
    {
        BookUI.FirstPersonController.ToggleMovement();
        yield return new WaitForSeconds(2.2f);
        BookUI.FirstPersonController.m_MouseLook.SetCursorLock(false);
        OpenBook();
    }

    private IEnumerator UIDisappearDelay()
    {
        ToggleBookCam();
        BookUI.FirstPersonController.m_MouseLook.SetCursorLock(true);
        yield return new WaitForSeconds(2.2f);
        BookUI.FirstPersonController.gameObject.GetComponent<PlayerInteraction>().ToggleInteraction();
        BookUI.FirstPersonController.ToggleMovement();
        ToggleCanBeInteractedWith();
    }
}

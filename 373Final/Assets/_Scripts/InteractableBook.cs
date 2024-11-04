using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class InteractableBook : Interactable
{
    [SerializeField] private string[] bookText;
    [SerializeField] private int currentPage = 1;
    [SerializeField] private AudioClip OpenBookSound;
    [SerializeField] private AudioClip CloseBookSound;
    [SerializeField] private Camera BookViewCamera;
    [SerializeField] private GameObject BookUI;


    public override void Activate()
    {
        OpenBook();
        ToggleCanBeInteractedWith();
    }

    private void OpenBook()
    {

    }

    public void CloseBook()
    {
        ToggleCanBeInteractedWith();
    }

    // enter 1 to go to next page, and -1 to go to the previous page
    public void ChangePage(int pageAmt)
    {

    }

    public void LookAtBook()
    {

    }

}

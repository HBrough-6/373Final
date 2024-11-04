using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    // text to display when reading a book
    private string[] textToDisplay;
    [SerializeField] private GameObject CurrentPageDisplay;
    [SerializeField] private GameObject TextDisplay;
    private int currentPage;

    [SerializeField] private GameObject book;

    public void ActivateBook(GameObject b)
    {
        // update the current page to the first
        currentPage = 1;
        // assign the books text to the storage variable
        textToDisplay = b.GetComponent<InteractableBook>().bookText;
        // update the current page in the UI
        CurrentPageDisplay.GetComponent<TMP_Text>().text = currentPage.ToString() + " / " + textToDisplay.Count().ToString();
        UpdatePageText();
        // turn on the UI
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void NextPage()
    {
        // checks if the current page is the last
        if (currentPage < textToDisplay.Count())
        {
            // current page increases
            currentPage++;
            // update the page text
            UpdatePageText();
        }
    }

    public void PreviousPage()
    {
        // checks if the current page is the last
        if (currentPage > 1)
        {
            // current page increases
            currentPage--;
            // update the page text
            UpdatePageText();
        }
    }

    private void UpdatePageText()
    {
        // update the text displayed in the UI
        TextDisplay.GetComponent<TMP_Text>().text = textToDisplay[currentPage - 1];

        // update the current page in the UI
        CurrentPageDisplay.GetComponent<TMP_Text>().text = currentPage.ToString() + " / " + textToDisplay.Count().ToString();
    }

    public void CloseBook()
    {
        // turn off the book UI
        transform.GetChild(0).gameObject.SetActive(false);
        book.GetComponent<InteractableBook>().CloseBook();
    }
}

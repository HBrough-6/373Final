using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    // text to display when reading a book
    private string[] textToDisplay;
    private string currentText;
    private GameObject CurrentPageDisplay;
    private int currentPage;

    public void ActivateBook(string[] pages)
    {
        // update the current page to the first
        currentPage = 1;
        // assign the books text to the storage variable
        textToDisplay = pages;
        // update the current page in the UI
        CurrentPageDisplay.GetComponent<TMP_Text>().text = currentPage.ToString() + " / " + textToDisplay.Count().ToString();
        // display the first page of text
        currentText = textToDisplay[currentPage];
        // turn on the UI       gameObject.SetActive(true);
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
        if (currentPage > textToDisplay.Count())
        {
            // current page increases
            currentPage++;
            // update the page text
            UpdatePageText();
        }
    }

    private void UpdatePageText()
    {
        // update the text displayed in the UI
        currentText = textToDisplay[currentPage];
        // update the current page in the UI
        CurrentPageDisplay.GetComponent<TMP_Text>().text = currentPage.ToString() + " / " + textToDisplay.Count().ToString();
    }

    public void CloseBook()
    {
        gameObject.SetActive(false);
    }
}

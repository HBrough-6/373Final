using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Elizeo_MainMenu : MonoBehaviour
{
    public void OnStartButton()
    {
        //SceneManager.LoadScene("_ElizeoScene");
        Debug.Log("Going to the Game Scene");
    }

    public void OnQuitButton()
    {
        //Application.Quit();
        Debug.Log("Quitting the Game");
    }
}

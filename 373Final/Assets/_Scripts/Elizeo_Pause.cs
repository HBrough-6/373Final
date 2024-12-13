using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elizeo_Pause : MonoBehaviour
{
    //Bool for the pause feature, Only sets the time scale to 0 and vice versa.
    [SerializeField] private bool isPaused;

    //Object for the Pause Canvas.
    [SerializeField] private GameObject pauseObject;

    //Object for the Map display on the pause menu.
    [SerializeField] private GameObject pauseMap;

    //Object for the in-game Minimap.
    [SerializeField] private GameObject gameMapObject;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseObject.SetActive(false);
        pauseMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WhilePausing();
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseObject.SetActive(true);
            gameMapObject.SetActive(false);
            isPaused = true;
        }

    }

    //What the pause bool is going to do.
    private void WhilePausing()
    {
        if (isPaused)
        {             
            Time.timeScale = 0;

            //Makes the cursor appear. Fixes a bug that freezes the game.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;

            //Makes the cursor disappear again and go back to player.
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void OnResumeButton()
    {
        pauseObject.SetActive(false);
        gameMapObject.SetActive(true);
        isPaused = false;
    }

    public void OnMapButton()
    {
        pauseMap.SetActive(true);
        pauseObject.SetActive(false);
    }

    public void OnReturnFromMap()
    {
        pauseMap.SetActive(false);
        pauseObject.SetActive(true);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene("_ElizeoMenu");
    }

}

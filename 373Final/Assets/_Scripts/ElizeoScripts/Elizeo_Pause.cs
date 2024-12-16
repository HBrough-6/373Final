using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elizeo_Pause : MonoBehaviour
{
    //Bool for the pause feature, Only sets the time scale to 0 and vice versa.
    [SerializeField] private bool isPaused;

    //Bool for the map in the pause setting. Shows the full map
    [SerializeField] private bool onMapMenu;

    //Object for the Pause Canvas.
    [SerializeField] private GameObject pauseObject;

    //Object for the Map display on the pause menu.
    [SerializeField] private GameObject pauseMap;

    //Object for the in-game Minimap.
    [SerializeField] private GameObject gameMapObject;

    //Object is basically a bigger crosshair that is easier for the player to see.
    //[SerializeField] private GameObject pauseCrosshair;


    //These crosshairs should be in the same location as the crosshairs in the Minimap
    //private Transform _pausedPlayerIcon;
    //private Transform _playerTransform; //Should find the player, just like in the Minimap Script.
    //[SerializeField] private float _pausedPlayerIconOffset;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        onMapMenu = false;
        pauseObject.SetActive(false);
        pauseMap.SetActive(false);
    //    FindPauseCrosshair();
    }

    // Update is called once per frame
    void Update()
    {
        WhilePausing();
        //        if (Input.GetKey(KeyCode.Escape))
        //        {
        //            pauseObject.SetActive(true);
        //            gameMapObject.SetActive(false);
        //            isPaused = true;
        //        }
  //      AdjustPlayertoPauseCrosshair();
    }

    //What the pause bool is going to do.
    private void WhilePausing()
    {
        if (isPaused)
        {             
            Time.timeScale = 0;

            //Makes the cursor appear. Fixes a bug that freezes the game.
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;


        }
        else
        {
            Time.timeScale = 1;

            //Makes the cursor disappear again and go back to player.
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;

            if (Input.GetKey(KeyCode.Escape))
            {
                pauseObject.SetActive(true);
                //gameMapObject.SetActive(false);
                isPaused = true;
            }
        }

        if (onMapMenu)
        {
      //      pauseCrosshair.SetActive(true);
        }
        else
        {
       //     pauseCrosshair.SetActive(false);
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
        //onMapMenu = true;
    }

    public void OnReturnFromMap()
    {
        pauseMap.SetActive(false);
        pauseObject.SetActive(true);
        onMapMenu = false;
    }

    public void OnQuitButton()
    {
        //SceneManager.LoadScene("_ElizeoMenu");
    }

  /*  private void FindPauseCrosshair()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject pausedPlayerIcon = GameObject.FindWithTag("PauseCrosshair");

        if (player != null)
            _playerTransform = player.GetComponent<Transform>();

        if (pausedPlayerIcon != null)
            _pausedPlayerIcon = pausedPlayerIcon.GetComponent<Transform>();
    }

    private void AdjustPlayertoPauseCrosshair()
    {
        if (_playerTransform != null && _pausedPlayerIcon != null)
        {
            // Match the sprite's position to the player's position
            _pausedPlayerIcon.transform.position = new Vector3(_playerTransform.position.x, transform.position.y + _pausedPlayerIconOffset, _playerTransform.position.z);

            // Calculate the desired rotation for the player icon
            Quaternion desiredRotation = Quaternion.Euler(90f, _playerTransform.eulerAngles.y, 0f);

            // Match the player icon's rotation to the desired rotation
            _pausedPlayerIcon.rotation = desiredRotation;

        }
    }
*/
}

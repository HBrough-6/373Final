using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*[Nava, Elizeo]
 *[November 13, 2024]
 *[This script is meant for tracking down the player on the minimap]
 */
public class Elizeo_Minimap : MonoBehaviour
{
    // [Header("Minimap rotations")]
    //public Transform playerReference;
    //  public float playerOffset;

    //This tracks down the player's position from the top. playerOffset determines how far the camera is facing from the player.
    //playerReference is the where the player object is located.
    // private void Update()
    // {
    //    if (playerReference != null)
    //    {
    //        transform.position = new Vector3(playerReference.position.x, playerReference.position.y + playerOffset, playerReference.position.z);
    //       transform.rotation = Quaternion.Euler(90f, playerReference.eulerAngles.y, 0f);
    //   }
    //  }

    private Transform _playerTransform;
    private Transform _playerIcon;
    [SerializeField] private float _playerIconOffset;

    [SerializeField] private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject playerIcon = GameObject.FindWithTag("PlayerIcon");

        if (player != null)
            _playerTransform = player.GetComponent<Transform>();

        if (playerIcon != null)
            _playerIcon = playerIcon.GetComponent<Transform>();
    }

    void Update()
    {
        if (_playerTransform != null && _playerIcon != null)
        {
            // Match the sprite's position to the player's position
            _playerIcon.transform.position = new Vector3(_playerTransform.position.x, transform.position.y + _playerIconOffset, _playerTransform.position.z);

            // Calculate the desired rotation for the player icon
            Quaternion desiredRotation = Quaternion.Euler(90f, _playerTransform.eulerAngles.y, 0f);

            // Match the player icon's rotation to the desired rotation
            _playerIcon.rotation = desiredRotation;

        }
    }
}

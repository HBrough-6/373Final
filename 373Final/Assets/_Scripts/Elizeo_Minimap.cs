using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*[Nava, Elizeo]
 *[November 13, 2024]
 *[This script is meant for tracking down the player on the minimap]
 */
public class Elizeo_Minimap : MonoBehaviour
{
    [Header("Minimap rotations")]
    public Transform playerReference;
    public float playerOffset;

    //This tracks down the player's position from the top. playerOffset determines how far the camera is facing from the player.
    //playerReference is the where the player object is located.
    private void Update()
    {
        if (playerReference != null)
        {
            transform.position = new Vector3(playerReference.position.x, playerReference.position.y + playerOffset, playerReference.position.z);
            transform.rotation = Quaternion.Euler(90f, playerReference.eulerAngles.y, 0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* [Nava, Elizeo]
 * [November 4, 2024]
 * [This is a singleton that should manage almost all the UI in the project]
 */
public class UIManager : MonoBehaviour
{
    //This is the instance
    //--------------------------------------------------------------------
    public static UIManager ui_Instance {  get; private set; }

    private void Awake()
    {
        if (ui_Instance != null && ui_Instance != this)
        {
            Destroy(this);
        }
        else
        {
            ui_Instance = this;
        }
    }
    //-------------------------------------------------------------------


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShowCurrentCoin : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private CoinTrayUI trayUI;
    [SerializeField] private string coinType;
    private bool isActive = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hui");
        // set this to the current coin
        trayUI.SetSelectedCoin(coinType, transform.position);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CoinTray : Interactable
{
    private List<GameObject> coins = new();

    [SerializeField] private GameObject copperCoinPrefab;
    [SerializeField] private GameObject silverCoinPrefab;
    [SerializeField] private GameObject goldCoinPrefab;

    private void Awake()
    {

    }

    public override void Activate()
    {
        // CoinTrayUI.Activate();
    }

    // spawn a coin at a random point on the tray
    public void SpawnCoin(string coinType)
    {
        // get random position within bounds
        // if the coin will touch another coin turn it into a stack
        // 
    }

    // remove all coins from the tray
    public void ClearTray()
    {

    }
}

using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CoinTray : Interactable
{
    // coins[stack][individual coin -- lower index, lower the in the stack]
    private List<List<GameObject>> coinStacks = new();
    // {Copper, Silver, Gold}
    private List<GameObject>[] coinTypes = { new List<GameObject>(), new List<GameObject>(), new List<GameObject>() };
    //private List<GameObject> coins = new();

    [SerializeField] private GameObject copperCoinPrefab;
    [SerializeField] private GameObject silverCoinPrefab;
    [SerializeField] private GameObject goldCoinPrefab;

    [SerializeField] BoxCollider coinSpawn;
    private Vector4 spawnBounds;

    [SerializeField] private float distBetweenStacks = 0.5f;

    private void Awake()
    {
        Bounds temp = coinSpawn.bounds;
        // (bottomleft.x, bottomleft.z, topRight.x, topright.z)
        spawnBounds = new Vector4(temp.center.x - temp.extents.x, temp.center.z - temp.extents.z, temp.center.x + temp.extents.x, temp.center.z + temp.extents.z);
    }

    public override void Activate()
    {
        // CoinTrayUI.Activate();
    }

    // spawn a coin at a random point on the tray
    public void SpawnCoin(string coinType)
    {
        
        // get random position within bounds
        float x = Random.Range(spawnBounds.x, spawnBounds.z);
        float z = Random.Range(spawnBounds.y, spawnBounds.w);
        Vector3 randPos = new Vector3(x, coinSpawn.transform.position.y, z);
        GameObject temp;
        switch (coinType)
        {
            case "Copper":
                temp = Instantiate(copperCoinPrefab, randPos, Quaternion.Euler(0, 0, 0));
                coinTypes[0].Add(temp);
                break;
            case "Silver":
                temp = Instantiate(silverCoinPrefab, randPos, Quaternion.Euler(0, 0, 0));
                coinTypes[1].Add(temp);
                break;
            case "Gold":
                temp = Instantiate(goldCoinPrefab, randPos, Quaternion.Euler(0, 0, 0));
                coinTypes[2].Add(temp);
                break;
            default:
                return;
        }

        bool stacked = false;
        // look through all the current coins and check the distance to each point
        for (int i = 0; i < coinStacks.Count && !stacked; i++)
        {
            // if the coin will touch another coin place it on top of the previous coin
            if (Vector3.Distance(temp.transform.position, coinStacks[i][0].transform.position) < distBetweenStacks)
            {
                coinStacks[i].Add(temp);

                stacked = true;
                // get the top coin on the stack
                Transform topCoin = coinStacks[i][coinStacks[i].Count - 1].transform.GetChild(1);
                // place the coin on the top of the stack
                temp.transform.position = new Vector3(topCoin.position.x, topCoin.position.y, topCoin.position.z);
            }
        }    
        
        // if the coin is not close enough to any stacks then create a new stack
        if (!stacked)
        {
            // else add a new stack to the list
            coinStacks.Add(new List<GameObject> { temp });
        }
        
        


    }

    // remove all coins from the tray
    public void ClearTray()
    {
        /*foreach (GameObject coin in coins)
        {
            Destroy(coin);
        }*/
    }

    private void OnGUI()
    {
        if (GUILayout.Button("press"))
        {
            
            switch (Random.Range(0, 3))
            {
                case 0:
                    SpawnCoin("Copper");
                    break;
                case 1:
                    SpawnCoin("Silver");
                    break;
                case 2:
                    SpawnCoin("Gold");
                    break;
                default:
                    break;
            }
        }
        if (GUILayout.Button("clear"))
        {
            ClearTray();
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CoinTray : Interactable
{
    // coins[stack][individual coin -- lower index, lower the in the stack]
    private List<List<GameObject>> coinStacks = new();
    // {Copper, Silver, Gold}
    private List<GameObject>[] coinTypes = { new List<GameObject>(), new List<GameObject>(), new List<GameObject>() };

    [SerializeField] private List<GameObject> goldList;
    //private List<GameObject> coins = new();

    [SerializeField] private GameObject copperCoinPrefab;
    [SerializeField] private GameObject silverCoinPrefab;
    [SerializeField] private GameObject goldCoinPrefab;

    [SerializeField] BoxCollider coinSpawn;
    private Vector4 spawnBounds;

    [SerializeField] private float distBetweenStacks = 0.05f;

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

        // get the SO attached to the coin
        CoinInfo tempInfo = temp.GetComponent<CoinInfoContainer>().info = (CoinInfo)ScriptableObject.CreateInstance("CoinInfo");

        bool stacked = false;
        // look through all the current coins and check the distance to each point
        for (int i = 0; i < coinStacks.Count && !stacked; i++)
        {
            // if the coin will touch another coin place it on top of the previous coin
            if (Vector3.Distance(temp.transform.position, coinStacks[i][0].transform.position) < distBetweenStacks)
            {
                // get the top coin on the stack
                Transform topCoin = coinStacks[i][coinStacks[i].Count - 1].transform.GetChild(1);
                // place the coin on the top of the stack
                temp.transform.position = new Vector3(topCoin.position.x, topCoin.position.y, topCoin.position.z);
                // add the coin to the stack's list
                coinStacks[i].Add(temp);
                // coin has been stacked
                stacked = true;
                // set coin info for easier destruction
                tempInfo.coinStack = i;
                tempInfo.posInStack = coinStacks[i].Count - 1;
            }
        }

        // if the coin is not close enough to any stacks then create a new stack
        if (!stacked)
        {
            // else add a new stack to the list
            coinStacks.Add(new List<GameObject> { temp });
            tempInfo.coinStack = coinStacks.Count - 1;
            tempInfo.posInStack = 0;
        }
    }

    // remove all coins from the tray
    public void ClearTray()
    {
        foreach (List<GameObject> coinList in coinTypes)
        {
            foreach (GameObject coin in coinList)
            {
                Destroy(coin);
            }
        }
        // clear all lists
        coinTypes[0].Clear();
        coinTypes[1].Clear();
        coinTypes[2].Clear();
        coinStacks = new();
    }

    public void RemoveCoin(string CoinType)
    {
        // get the coin index
        int coinTypeIndex = 0;
        switch (CoinType)
        {
            case "Copper":
                coinTypeIndex = 0;
                break;
            case "Silver":
                coinTypeIndex = 1;
                break;
            case "Gold":
                coinTypeIndex = 2;
                break;
            default:
                break;
        }

        // get a reference to the most recent coin and its info
        GameObject temp = coinTypes[coinTypeIndex][coinTypes[coinTypeIndex].Count - 1];
        CoinInfo tempInfo = temp.GetComponent<CoinInfoContainer>().info;
        float distBetweenCoins = (temp.transform.GetChild(1).position.y - temp.transform.position.y) * -1;
        // store the coin's values
        int posInStack = tempInfo.posInStack;
        int stack = tempInfo.coinStack;

        // remove the coin from both data structures
        coinTypes[coinTypeIndex].Remove(temp);
        Debug.Log(posInStack + " " + coinStacks[stack].Count);
        // coinStacks[stack].Find(coinStacks[stack][posInStack]); trying to find if the coin is actually in the stack when it is being destroyed
        coinStacks[stack].Remove(coinStacks[stack][posInStack]);



        // destroy the coin
        Destroy(temp);

        // if the stack is empty then get rid of it
        if (coinStacks[stack].Count < 1)
        {
            coinStacks.Remove(coinStacks[stack]);
            // when removing a stack, update the stack number of all higher stacks
            for (int i = stack; i < coinStacks.Count; i++)
            {
                foreach (GameObject coin in coinStacks[i])
                {
                    coin.GetComponent<CoinInfoContainer>().info.coinStack = i;
                }
            }
        }

        // stack is not empty, move coins
        else
        {
            // go through all coins above and move them down
            for (int i = posInStack; i < coinStacks[stack].Count; i++)
            {
                coinStacks[stack][i].transform.Translate(new Vector3(0, distBetweenCoins, 0));
                // update the position in the stack
                coinStacks[stack][i].GetComponent<CoinInfoContainer>().info.posInStack = i;
            }
        }
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
        if (GUILayout.Button("destroy copper"))
        {
            RemoveCoin("Copper");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int copperCoins = 0;
    [SerializeField] private int silverCoins = 0;
    [SerializeField] private int goldCoins = 0;
    [SerializeField] private int score = 0;

    public static PlayerInventory Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }


    public int CopperCoins
    {
        get
        {
            return copperCoins;
        }
    }

    public int SilverCoins
    {
        get
        {
            return copperCoins;
        }
    }

    public int GoldCoins
    {
        get
        {
            return copperCoins;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }


    public void IncreaseScore(int points)
    {
        score += points;
        // do something in the ui
        // play a sound
    }

    public void addCopperCoins(int amt)
    {
        copperCoins += amt;
        // do something in the UI
        // play a sound
    }

    public void addSilverCoins(int amt)
    {
        silverCoins += amt;
        // do something in the ui
        // play a sound
    }

    public void addGoldCoins(int amt)
    {
        goldCoins += amt;
        // do something in the ui
        // play a sound
    }
}

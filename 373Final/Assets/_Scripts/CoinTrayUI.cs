using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinTrayUI : MonoBehaviour
{
    [SerializeField] private int currentCopperCoins = 0;
    [SerializeField] private int currentSilverCoins = 0;
    [SerializeField] private int currentGoldCoins = 0;

    [SerializeField] private int playerCopperCoins = 0;
    [SerializeField] private int playerSilverCoins = 0;
    [SerializeField] private int playerGoldCoins = 0;

    [SerializeField] private int currentWeight = 0;
    [SerializeField] private int targetWeight = 1;

    [SerializeField] private bool completed = false;

    // coin weights
    private int copperWeight = 7;
    private int silverWeight = 9;
    private int goldWeight = 17;

    private int totalWeight = 0;

    // coin parents
    [SerializeField] private Transform CopperParent;
    [SerializeField] private Transform SilverParent;
    [SerializeField] private Transform GoldParent;

    // button references
    private Button MoreCopperButton;
    private Button LessCopperButton;

    private Button MoreSilverButton;
    private Button LessSilverButton;

    private Button MoreGoldButton;
    private Button LessGoldButton;

    // text references
    private TMP_Text copperCountText;
    private TMP_Text silverCountText;
    private TMP_Text goldCountText;



    

    [SerializeField] private GameObject copperCoinPrefab;
    [SerializeField] private GameObject silverCoinPrefab;
    [SerializeField] private GameObject goldCoinPrefab;

    private void Awake()
    {
        // assign buttons
        MoreCopperButton = CopperParent.GetChild(0).GetComponent<Button>();
        LessCopperButton = CopperParent.GetChild(1).GetComponent<Button>();

        MoreSilverButton = SilverParent.GetChild(0).GetComponent<Button>();
        LessSilverButton = SilverParent.GetChild(1).GetComponent<Button>();

        MoreGoldButton = GoldParent.GetChild(0).GetComponent<Button>();
        LessGoldButton = GoldParent.GetChild(1).GetComponent<Button>();

        // Assign coin count text
        copperCountText = CopperParent.GetChild(2).GetComponent<TMP_Text>();
        silverCountText = SilverParent.GetChild(2).GetComponent<TMP_Text>();
        goldCountText = GoldParent.GetChild(2).GetComponent<TMP_Text>();

        OpenUI();
    }

   
    // keep change to either -1 or 1
    public void ChangeCopperCoinCount(int change)
    {
        currentCopperCoins += change;
        CheckCoinButtonStatuses("Copper");
        copperCountText.text = currentCopperCoins.ToString();
    }

    // keep change to either -1 or 1
    public void ChangeSilverCoinCount(int change)
    {
        currentSilverCoins += change;
        CheckCoinButtonStatuses("Silver");
        silverCountText.text = currentSilverCoins.ToString();
    }

    // keep change to either -1 or 1
    public void ChangeGoldCoinCount(int change)
    {
        currentGoldCoins += change;
        CheckCoinButtonStatuses("Gold");
        goldCountText.text = currentGoldCoins.ToString();
    }


    private void CheckCoinButtonStatuses(string coinType)
    {
        switch (coinType)
        {
            // check copper
            case "Copper":
                if (currentCopperCoins <= 0)
                {
                    // can't go any lower, disable less copper coins button
                    LessCopperButton.interactable = false;
                }
                else
                {
                    // can go lower, enable less copper coins button
                    LessCopperButton.interactable = true;
                }

                if (currentCopperCoins >= playerCopperCoins)
                {
                    // can't go any higher, disable more copper coins button
                    MoreCopperButton.interactable = false;
                }
                else
                {
                    // can go higher, enable more copper coins button
                    MoreCopperButton.interactable = true;
                }
                break;


            case "Silver":
                if (currentSilverCoins <= 0)
                {
                    // can't go any lower, disable less copper coins button
                    LessSilverButton.interactable = false;
                }
                else
                {
                    // can go lower, enable less copper coins button
                    LessSilverButton.interactable = true;
                }

                if (currentSilverCoins >= playerSilverCoins)
                {
                    // can't go any higher, disable more copper coins button
                    MoreSilverButton.interactable = false;
                }
                else
                {
                    // can go higher, enable more copper coins button
                    MoreSilverButton.interactable = true;
                }
                break;


            case "Gold":
                if (currentGoldCoins <= 0)
                {
                    // can't go any lower, disable less copper coins button
                    LessGoldButton.interactable = false;
                }
                else
                {
                    // can go lower, enable less copper coins button
                    LessGoldButton.interactable = true;
                }

                if (currentGoldCoins >= playerGoldCoins)
                {
                    // can't go any higher, disable more copper coins button
                    MoreGoldButton.interactable = false;
                }
                else
                {
                    // can go higher, enable more copper coins button
                    MoreGoldButton.interactable = true;
                }
                break;
            default:
                Debug.Log("what is " + coinType + "?? Copper, Silver, or Gold please");
                break;
        }

    }

    public void OpenUI()
    {
        // set UI active
        // check button statuses
        CheckCoinButtonStatuses("Copper");
        CheckCoinButtonStatuses("Silver");
        CheckCoinButtonStatuses("Gold");
        // get the players coin counts
        // playerCopperCoins = PlayerInteraction.Instance.copperCoins
        // playerSilverCoins = PlayerInteraction.Instance.silverCoins
        // playerGoldCoins = PlayerInteraction.Instance.goldCoins
    }

    public void CloseUI()
    {
        // reset the coins currently on the tray
        // get rid of all coins on the tray

    }
}

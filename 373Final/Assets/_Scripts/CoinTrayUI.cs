using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
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

    [SerializeField] private CoinTray tray;

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
    private GameObject MoreCopperButton;
    private GameObject LessCopperButton;

    private GameObject MoreSilverButton;
    private GameObject LessSilverButton;

    private GameObject MoreGoldButton;
    private GameObject LessGoldButton;

    // text references
    private TMP_Text copperCountText;
    private TMP_Text silverCountText;
    private TMP_Text goldCountText;

    // selected coin references
    private float copperThreshold;
    private float goldThreshold;

    private Transform copperBackground;
    private Transform silverBackground;
    private Transform goldBackground;

    private string currentlyMousedOverCoinType = "Copper";

    // currently moused over coin reference
    [SerializeField] private Transform mousedOver;

    private void Awake()
    {
        // assign coin backgrounds
        copperBackground = transform.GetChild(0).GetChild(1);
        silverBackground = transform.GetChild(0).GetChild(2);
        goldBackground = transform.GetChild(0).GetChild(3);


        // assign buttons
        MoreCopperButton = CopperParent.GetChild(0).gameObject;
        LessCopperButton = CopperParent.GetChild(1).gameObject;

        MoreSilverButton = SilverParent.GetChild(0).gameObject;
        LessSilverButton = SilverParent.GetChild(1).gameObject;

        MoreGoldButton = GoldParent.GetChild(0).gameObject;
        LessGoldButton = GoldParent.GetChild(1).gameObject;

        // Assign coin count text
        copperCountText = CopperParent.GetChild(2).GetComponent<TMP_Text>();
        silverCountText = SilverParent.GetChild(2).GetComponent<TMP_Text>();
        goldCountText = GoldParent.GetChild(2).GetComponent<TMP_Text>();

        Bounds temp = silverBackground.GetComponent<BoxCollider2D>().bounds;
        copperThreshold = temp.center.x - temp.extents.x;
        goldThreshold = temp.center.x + temp.extents.x;

        OpenUI();
    }

    private void Update()
    {
        // get mouse position
        // compare it
        // move the selector
        Vector2 temp = Input.mousePosition;

        if (temp.x < copperThreshold && currentlyMousedOverCoinType != "Copper")
        {
            SetSelectedCoin("Copper", copperBackground.position);
        }
        else if (temp.x > goldThreshold && currentlyMousedOverCoinType != "Gold")
        {
            SetSelectedCoin("Gold", goldBackground.position);
        }
        else if (currentlyMousedOverCoinType != "Silver" && temp.x > copperThreshold && temp.x < goldThreshold)
        {
            SetSelectedCoin("Silver", silverBackground.position);
        }
    }


    // keep change to either -1 or 1
    public void ChangeCopperCoinCount(int change)
    {
        currentCopperCoins += change;
        if (change == 1)
        {
            tray.SpawnCoin("Copper");
        }
        else
        {
            tray.RemoveCoin("Copper");
        }
        CheckCoinButtonStatuses("Copper");
        copperCountText.text = currentCopperCoins.ToString();
    }

    // keep change to either -1 or 1
    public void ChangeSilverCoinCount(int change)
    {
        currentSilverCoins += change;
        if (change == 1)
        {
            tray.SpawnCoin("Silver");
        }
        else
        {
            tray.RemoveCoin("Silver");
        }
        CheckCoinButtonStatuses("Silver");
        silverCountText.text = currentSilverCoins.ToString();
    }

    // keep change to either -1 or 1
    public void ChangeGoldCoinCount(int change)
    {
        currentGoldCoins += change;
        if (change == 1)
        {
            tray.SpawnCoin("Gold");
        }
        else
        {
            tray.RemoveCoin("Gold");
        }
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
                    LessCopperButton.SetActive(false);
                }
                else
                {
                    // can go lower, enable less copper coins button
                    LessCopperButton.SetActive(true);
                }

                if (currentCopperCoins >= playerCopperCoins)
                {
                    // can't go any higher, disable more copper coins button
                    MoreCopperButton.SetActive(false);
                }
                else
                {
                    // can go higher, enable more copper coins button
                    MoreCopperButton.SetActive(true);
                }
                break;


            case "Silver":
                if (currentSilverCoins <= 0)
                {
                    // can't go any lower, disable less copper coins button
                    LessSilverButton.SetActive(false);
                }
                else
                {
                    // can go lower, enable less copper coins button
                    LessSilverButton.SetActive(true);
                }

                if (currentSilverCoins >= playerSilverCoins)
                {
                    // can't go any higher, disable more copper coins button
                    MoreSilverButton.SetActive(false);
                }
                else
                {
                    // can go higher, enable more copper coins button
                    MoreSilverButton.SetActive(true);
                }
                break;


            case "Gold":
                if (currentGoldCoins <= 0)
                {
                    // can't go any lower, disable less copper coins button
                    LessGoldButton.SetActive(false);
                }
                else
                {
                    // can go lower, enable less copper coins button
                    LessGoldButton.SetActive(true);
                }

                if (currentGoldCoins >= playerGoldCoins)
                {
                    // can't go any higher, disable more copper coins button
                    MoreGoldButton.SetActive(false);
                }
                else
                {
                    // can go higher, enable more copper coins button
                    MoreGoldButton.SetActive(true);
                }
                break;
            default:
                Debug.Log("what is " + coinType + "?? Copper, Silver, or Gold please");
                break;
        }
    }

    private void UpdateWeightInUI()
    {   ////////////////////////////////////////////////////////////////////////////// do this
        currentWeight = currentCopperCoins * copperWeight + currentSilverCoins * silverWeight + currentGoldCoins * goldWeight;
        string weightInString = currentWeight.ToString();
    }

    public void SetSelectedCoin(string coinType, Vector3 position)
    {
        
        // set the correct buttons active and all others inactive
        mousedOver.position = position;
        MoreCopperButton.SetActive(false);
        LessCopperButton.SetActive(false);
        MoreSilverButton.SetActive(false);
        LessSilverButton.SetActive(false);
        MoreGoldButton.SetActive(false);
        LessGoldButton.SetActive(false);

        CheckCoinButtonStatuses(coinType);
        currentlyMousedOverCoinType = coinType;

        // move the selector to the right position
        mousedOver.position = position;
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

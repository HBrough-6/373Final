using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinInfo", menuName = "Coins/CoinInfo")]
public class CoinInfo : ScriptableObject
{
    public int stack = -1;
    public int stackPos = -1; 
}

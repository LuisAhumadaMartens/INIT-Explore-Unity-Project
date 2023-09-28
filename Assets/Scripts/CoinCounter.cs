using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI coinText;

    public void AddCoin()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }
}

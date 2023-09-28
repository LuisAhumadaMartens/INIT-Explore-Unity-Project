using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private CoinCounter coinCounter;

    private void Start()
    {
        coinCounter = FindObjectOfType<CoinCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        coinCounter.AddCoin();
        Destroy(gameObject);
    }
}
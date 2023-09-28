using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class EventManager : MonoBehaviour
{
    private int coins = 0;
    private bool timeRunning = false;
    [HideInInspector] public float currentTime = 0;
    [SerializeField] private TextMeshProUGUI currentTimeTextBox;

    void Start()
    {
        // Get our saved values and display them.
        //lives = PlayerPrefs.GetInt("playerLives");
        //coins = PlayerPrefs.GetInt("playerCurrency");
        
        // Backups are useful for 
        //backuplives = lives;
        //backupcoins = coins;
    }

    void Update()
    {
        if (timeRunning)
        {
            currentTime += Time.deltaTime;
            currentTimeTextBox.text = floatToTime(currentTime);
        }
    }

    public int getCoins()
    {
        return coins;
    }
    public void addCoins(int coinsModifier)
    {
        coins += coinsModifier;
    }
    public void setCoins(int coinsModifier)
    {
        coins = coinsModifier;
    }

    private String floatToTime(float time)
    {
        TimeSpan timeInTimeSpan = TimeSpan.FromSeconds(time);
        string text = string.Format("{0:D2}:{1:D2}", timeInTimeSpan.Minutes, timeInTimeSpan.Seconds);
        if (text.Substring(0, 1).Equals("0"))
            return text.Substring(1, 4);
        return text;
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}

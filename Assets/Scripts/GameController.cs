using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject gameOver;
    public float score;

    public Text scoreText;
    public Text scoreCoinText;
    public int scoreCoin;
    private Player player;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
    }


    void Update()
    {
        if (!player.isDead)
        {
            score += Time.deltaTime * 10f;
            scoreText.text = Math.Round(score).ToString() + " m";
            
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void AddCoin(int value)
    {
        scoreCoin += value;
        scoreCoinText.text = scoreCoin.ToString();
    }
}

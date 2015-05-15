﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lifeScreenController : MonoBehaviour {


    private Text lifeText;
    private Text scoreText;
    private Text coinText;

	void Start () {
        GameObject liTemp = GameObject.FindGameObjectWithTag("ui_lives");
        lifeText = liTemp.GetComponent<Text>();

        scoreText = GameObject.FindGameObjectWithTag("ui_score").GetComponent<Text>();
        coinText = GameObject.FindGameObjectWithTag("ui_coins").GetComponent<Text>();

        if (PlayerPrefs.HasKey("lives"))
        {
            lifeText.text = PlayerPrefs.GetInt("lives") + "";
        }
        if (PlayerPrefs.HasKey("score"))
        {
            GameObject scTemp = GameObject.FindGameObjectWithTag("ui_score");
            scoreText = scTemp.GetComponent<Text>();
            string score = PlayerPrefs.GetInt("score") + "";
            string front = "";
            for (int i = 0; i < 6 - score.Length; i++)
            {
                front += "0";
            }
            scoreText.text = front + score;
        }
        if (PlayerPrefs.HasKey("coins"))
        {
            GameObject coTemp = GameObject.FindGameObjectWithTag("ui_coins");
            coinText = coTemp.GetComponent<Text>();
            string coin = PlayerPrefs.GetInt("coins") + "";
            string front = "";
            for (int i = 0; i < 2 - coin.Length; i++)
            {
                front += "0";
            }
            coinText.text = front + coin;
        }
       
        Invoke("loadGame", 2f);
	}

    void loadGame()
    {
        Application.LoadLevel(2);
    }
}

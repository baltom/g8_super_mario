using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiController : MonoBehaviour {
	
	private Text scoreText;
	private Text timeText;
	private Text coinText;
    private Text topScoreText;
    private Text livesText;

    public static uiController instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }

        //Henter inn alle UI elementene må endres
        GameObject scTemp = GameObject.FindGameObjectWithTag("ui_score");
        GameObject tiTemp = GameObject.FindGameObjectWithTag("ui_time");
        GameObject coTemp = GameObject.FindGameObjectWithTag("ui_coins");
        GameObject toTemp = GameObject.FindGameObjectWithTag("ui_topScore");
        GameObject liTemp = GameObject.FindGameObjectWithTag("ui_lives");

        scoreText = scTemp.GetComponent<Text>();
        if (tiTemp != null) {
            timeText = tiTemp.GetComponent<Text>();
        }
        if (toTemp != null) {
            topScoreText = toTemp.GetComponent<Text>();
        }
        if (liTemp != null) {
            livesText = liTemp.GetComponent<Text>();
        }
        coinText = coTemp.GetComponent<Text>();
    }

	//Legger til ekstra 0'er forran en string
	private string formatString(string input, int length) {
		string returnString = "";
		for (int i = 0; i < length-input.Length; i++) {
			returnString += "0";
		}
		return returnString + input;
	}
	
	private void setTimeText(string time) {
		timeText.text = formatString (time, 3);
	}
	
	private void setScoreText(string score) {
		scoreText.text = formatString (score, 6);
	}
	
	private void setCoinText(string coin) {
		coinText.text = formatString (coin, 2);
	}

    private void setTopScoreText(string score)
    {
        topScoreText.text = "TOP- " + formatString(score, 6);
    }

    private void setLivesText(string lives)
    {
        livesText.text = lives;
    }
	
	public void setTime(int time) {
		setTimeText(time + "");
	}
	
	public void setCoins(int coins) {
		setCoinText(coins + "");
	}
	
	public void setScore(int score) {
		setScoreText(score + "");
	}

    public void setTopScore(int score)
    {
        setTopScoreText(score + "");
    }

    public void setLives(int lives)
    {
        setLivesText(lives + "");
    }
}

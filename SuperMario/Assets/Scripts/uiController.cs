using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiController : MonoBehaviour {
	
	private Text scoreText;
	private Text timeText;
	private Text coinText;
    private Text topScoreText;
    private Text livesText;
    private Text popupText;
    private GameObject popup;

    private Vector2 popupPos;

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
        GameObject poTemp = GameObject.FindGameObjectWithTag("ui_popup");

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
        if (poTemp != null) {
            popupText = poTemp.GetComponent<Text>();
            popup = poTemp;
            popup.SetActive(false);
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

    public void setPopup(int score, Vector2 pos) {
        popupPos = pos;
        popupText.text = score + "";
        RectTransform pop = popup.GetComponent<RectTransform>();
        pop.anchorMin = pos;
        pop.anchorMax = pos;
        //popup.GetComponent<RectTransform>().localPosition = pos;
        popup.SetActive(true);
        InvokeRepeating("movePopup", 0f, 0.05f);
        Invoke("hidePopup", 1f);
        
    }

    private void movePopup() {
        popupPos = new Vector2(popupPos.x, popupPos.y + 0.01f);
        RectTransform pop = popup.GetComponent<RectTransform>();
        pop.anchorMin = popupPos;
        pop.anchorMax = popupPos;
    }

    private void hidePopup() {
        CancelInvoke();
        popup.SetActive(false);
    }
}

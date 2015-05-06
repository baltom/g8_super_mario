using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiController : MonoBehaviour {

	private Text scoreText;
	private Text timeText;
	private Text coinText;

	// Use this for initialization
	void Start () {
		GameObject scTemp = GameObject.FindGameObjectWithTag("ui_score");
		GameObject tiTemp = GameObject.FindGameObjectWithTag("ui_time");
		GameObject coTemp = GameObject.FindGameObjectWithTag("ui_coins");
		scoreText = scTemp.GetComponent<Text>();
		timeText = tiTemp.GetComponent<Text>();
		coinText = coTemp.GetComponent<Text> ();
	}
	
	public void increaseScore(int score) {
		int currentScore;
		int.TryParse (scoreText.text, out currentScore);
		currentScore += score;
		scoreText.text = currentScore + "";
	}

	public void increaseCoin() {
		int currentCoin;
		int.TryParse (coinText.text, out currentCoin);
		currentCoin++;
		coinText.text = currentCoin + "";
	}

	public void decreaseTime() {
		int currentTime;
		int.TryParse (timeText.text, out currentTime);
		currentTime--;
		timeText.text = currentTime + "";
	}
}

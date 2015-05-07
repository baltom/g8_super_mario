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
	
	public void setTime(int time) {
		setTimeText(time + "");
	}
	
	public void setCoins(int coins) {
		setCoinText(coins + "");
	}
	
	public void setScore(int score) {
		setScoreText(score + "");
	}
}

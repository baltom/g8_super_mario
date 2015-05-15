using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverController : MonoBehaviour {

    private Text scoreText;
    private Text coinText;

	// Use this for initialization
	void Start () {
       
        if (PlayerPrefs.HasKey("score"))
        {
            GameObject scTemp = GameObject.FindGameObjectWithTag("ui_score");
            scoreText = scTemp.GetComponent<Text>();
            string score = PlayerPrefs.GetInt("score")+"";
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
        Invoke("restart", 4.5f);
	}

    void restart()
    {
        Application.LoadLevel(0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

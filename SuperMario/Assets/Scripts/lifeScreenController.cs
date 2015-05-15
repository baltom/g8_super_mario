using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lifeScreenController : MonoBehaviour {


    private Text lifeText;
    private Text scoreText;
    private Text coinText;

	void Start () {
        
        if (PlayerPrefs.HasKey("lives")) {
            uiController.instance.setLives(PlayerPrefs.GetInt("lives"));
        }
        if (PlayerPrefs.HasKey("score")) {
            uiController.instance.setScore(PlayerPrefs.GetInt("score"));
        }
        if (PlayerPrefs.HasKey("coins")) {
            uiController.instance.setCoins(PlayerPrefs.GetInt("coins"));
        }
        Invoke("loadGame", 2f);
	}

    void loadGame()
    {
        Application.LoadLevel(2);
    }
}

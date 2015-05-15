using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startMenuController : MonoBehaviour {

    private int selection = 1;
    private RectTransform selector;

    private Text topScore;

    private int upPosition = -28;
    private int downPosition = -73;

    void Awake()
    {
        selector = GameObject.FindGameObjectWithTag("ui_selector").GetComponent<RectTransform>();
        selector.localPosition = new Vector3(-150f, upPosition, 0);
    }

    void Start() {
        if (PlayerPrefs.HasKey("topScore")) {
            uiController.instance.setTopScore(PlayerPrefs.GetInt("topScore"));
        }
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selection--;
            if (selection < 1) selection = 1;
            selector.localPosition = new Vector3(-150f, upPosition, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selection++;
            if (selection > 2) selection = 2;
            selector.localPosition = new Vector3(-150f, downPosition, 0);
        }
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && selection == 1)
        {
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("coins", 0);
            PlayerPrefs.SetInt("lives", 3);
            Application.LoadLevel(1);
        } 
	}
}

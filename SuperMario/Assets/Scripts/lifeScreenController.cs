using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lifeScreenController : MonoBehaviour {


    private Text lifeText;

	void Start () {
        GameObject liTemp = GameObject.FindGameObjectWithTag("ui_lives");
        lifeText = liTemp.GetComponent<Text>();
        GameObject lifeMng = GameObject.Find("lifeManager");
        if (lifeMng != null) { 
            lifeText.text = lifeMng.GetComponent<lifeManager>().lives+"";
        }
        Invoke("loadGame", 2f);
	}

    void loadGame()
    {
        Application.LoadLevel(2);
    }
}

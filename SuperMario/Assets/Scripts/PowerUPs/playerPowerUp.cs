using UnityEngine;
using System.Collections;

public class playerPowerUp : MonoBehaviour {
	bool playerLarge = false;

	public void mushroom (int value) {
		Debug.Log("HIT");
		if (value < 1000) {
			GM.instance.oneUp ();
		} else if (!playerLarge) {
			Debug.Log("HITGROW");
			GM.instance.marioGrow ();
			GM.instance.addScore (value);
		} else {
			GM.instance.addScore (value);
		}

	}
}

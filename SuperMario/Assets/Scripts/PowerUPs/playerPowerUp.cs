using UnityEngine;
using System.Collections;

public class playerPowerUp : MonoBehaviour {
	bool playerLarge = false;

	public void mushroom (int value) {
		if (value < 1000) {
			GM.instance.oneUp ();
		} else if (!playerLarge) {
			GM.instance.marioGrow ();
			GM.instance.addScore (value);
		} else {
			GM.instance.addScore (value);
		}

	}
}

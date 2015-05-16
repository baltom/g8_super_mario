using UnityEngine;
using System.Collections;

public class playerPowerUp : MonoBehaviour {


	public void mushroom (int value) {
		if (value < 1000) {
			GM.instance.oneUp ();
		} else if (!GM.instance.checkBig ()) {
			GM.instance.marioGrow ();
			GM.instance.addScore (value);
		} else {
			GM.instance.addScore (value);
		}

	}
}

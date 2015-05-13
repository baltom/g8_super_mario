using UnityEngine;
using System.Collections;

public class bricks : boxBehaviour {

	new void Hit  () {
		if (!GM.instance.checkBig ()) {
			soundController.instance.playClip("smb_bump.wav");
			animate ();
		} else {
			soundController.instance.playClip("smb_breakblock.wav");
			Destroy(gameObject);
			addScore(value);
		}
	}

}

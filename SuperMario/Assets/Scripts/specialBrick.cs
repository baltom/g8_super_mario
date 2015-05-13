using UnityEngine;
using System.Collections;

public class specialBrick : boxBehaviour {

		int counter;
	new void Hit () {

		Debug.Log(counter);
		if (!exhausted) {
			if(counter != 9) {
				animate();
				timedSpawn(0.5f);
				counter++;
			} else {
				animate();
				timedSpawn(0.5f);
				exhaust();
			}
		}
		soundController.instance.playClip("smb_bump.wav");
	}
}

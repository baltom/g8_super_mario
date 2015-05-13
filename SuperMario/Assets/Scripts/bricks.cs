using UnityEngine;
using System.Collections;

public class bricks : boxBehaviour {

	public AudioClip breakSound, bumpSound;

	new void Hit  () {
		if (!GM.instance.checkBig ()) {
			soundController.instance.playSound(bumpSound);
			animate ();
<<<<<<< HEAD

		else {
=======
		} else {
			soundController.instance.playSound(breakSound);
>>>>>>> origin/master
			Destroy(gameObject);
			addScore(value);
		}
	}

}

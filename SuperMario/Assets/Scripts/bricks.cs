using UnityEngine;
using System.Collections;

public class bricks : boxBehaviour {

	new void Hit  () {
		if(!GM.instance.checkBig())
			animate ();
		else {
			Destroy(gameObject);
		}
	}

}

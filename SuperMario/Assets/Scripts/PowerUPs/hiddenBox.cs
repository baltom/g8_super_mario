using UnityEngine;
using System.Collections;

public class hiddenBox : boxBehaviour {
	
	new void Hit() {
		if (!exhausted) {
			animate ();
			BoxCollider2D boxColl = GetComponent<BoxCollider2D> ();
			boxColl.enabled = true;
			timedSpawn (0.5f);
			exhaust ();
		}
	}
}

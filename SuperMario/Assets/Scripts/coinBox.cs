using UnityEngine;
using System.Collections;

public class coinBox : boxBehaviour {
	public Sprite boxExhausted;
	private bool exhausted = false;

	public void Hit() {
		if (!exhausted) {
			sr.sprite = boxExhausted;
			Animate ();
			exhausted = true;
		}
	}
}

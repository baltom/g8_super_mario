using UnityEngine;
using System.Collections;

public class coinBoxBehaviour : boxBehaviour {


	public override void exhaust() {
		gameObject.SendMessageUpwards("disableParent");
		sr.sprite = boxExhausted;
		exhausted = true;
	}
	


	
}

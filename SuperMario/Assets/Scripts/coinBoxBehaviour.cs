using UnityEngine;
using System.Collections;

public class coinBoxBehaviour : boxBehaviour {


	public override void exhaust() {
		//For å kunne spille av animasjoner og bytt sprite når boksen blir bumpet i.
		gameObject.SendMessageUpwards("disableParent");
		sr.sprite = boxExhausted;
		exhausted = true;
	}
	


	
}

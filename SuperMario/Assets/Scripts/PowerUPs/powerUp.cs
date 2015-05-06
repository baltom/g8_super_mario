using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {
	
	private bool playerHit;
	
	public int value;


	/*public void spriteChange(Sprite newSprite) {
		sr.sprite = newSprite;
	}*/



	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player"){
			Destroy (gameObject);
			GM.instance.addCoin(value);
		}
	}
}


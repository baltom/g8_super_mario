using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {
	
	private bool playerHit;
	
	public int value;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player"){
			Destroy (transform.parent.gameObject);
			GM.instance.addCoin(value);
		}
	}
}


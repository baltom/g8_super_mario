using UnityEngine;
using System.Collections;

public class mushroomCollision : mushroom {

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("HIT");
		if (coll.gameObject.tag == "Player"){
			Debug.Log("HIT2");
			Destroy (transform.parent.gameObject);
			coll.gameObject.SendMessage ("mushroom", value);
		}
	}
}

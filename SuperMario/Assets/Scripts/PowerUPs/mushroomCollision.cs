using UnityEngine;
using System.Collections;

public class mushroomCollision : mushroom {

	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.gameObject.tag == "Player"){

			Destroy (transform.parent.gameObject);
			coll.gameObject.SendMessage ("mushroom", value);
		}
	}
}

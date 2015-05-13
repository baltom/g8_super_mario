using UnityEngine;
using System.Collections;

public class pitCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			GM.instance.damageState();
			Destroy(coll.gameObject);
		}
	}
}

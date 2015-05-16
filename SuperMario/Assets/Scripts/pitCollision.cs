using UnityEngine;
using System.Collections;

public class pitCollision : MonoBehaviour {
	//Om mario faller i noen av fallgruvene.
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			GM.instance.damageState();
			Destroy(coll.gameObject);
		}
	}
}

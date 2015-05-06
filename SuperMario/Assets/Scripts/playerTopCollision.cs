using UnityEngine;
using System.Collections;

public class playerTopCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
	if (coll.gameObject.layer == LayerMask.NameToLayer("Box")) 
		coll.gameObject.SendMessage ("Hit");
	}
		
}

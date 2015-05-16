using UnityEngine;
using System.Collections;

public class pipeEntrance : MonoBehaviour {
	private bool cooldown = true;
	public int value;
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && cooldown) {
			coll.gameObject.SendMessage ("secretEntrance", value);
			cooldown = false;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && !cooldown) {
			coll.gameObject.SendMessage ("secretEntrance", value);
			cooldown = true;
		}
	}
}

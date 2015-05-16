using UnityEngine;
using System.Collections;

//Sender en melding til playerControll om spilleren står på en hemmelig inngang eller ikke.
//Brukes til både utgang og inngang.
//int value bestemmer hvilken type utgang/inngang det er.

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

using UnityEngine;
using System.Collections;
//Script for å animere vokseanimasjonen og for å ikke kunne la bruker styre før animasjonen har spilt 3 ganger.
public class marioLargeStart : MonoBehaviour {

	void Awake() {
		gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		Invoke("enableScript", 0.7f);
	}

	void enableScript(){
		gameObject.GetComponent<playerController>().enabled = true;
		gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
	}
}

using UnityEngine;
using System.Collections;

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

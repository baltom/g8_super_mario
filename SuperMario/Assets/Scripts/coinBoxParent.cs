using UnityEngine;
using System.Collections;

public class coinBoxParent : MonoBehaviour {

	public void disableParent() {
		//Skrur av alle idle animasjoner for boksen.
		gameObject.GetComponent<Animator>().enabled = false;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
}

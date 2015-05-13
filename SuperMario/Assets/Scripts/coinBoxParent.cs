using UnityEngine;
using System.Collections;

public class coinBoxParent : MonoBehaviour {

	public void disableParent() {
		gameObject.GetComponent<Animator>().enabled = false;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
}

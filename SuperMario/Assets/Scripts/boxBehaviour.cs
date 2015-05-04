using UnityEngine;
using System.Collections;

public class boxBehaviour : MonoBehaviour {

	private bool hit = false;

	private Animator anim;
	public SpriteRenderer sr;


	void Awake(){
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer> ();
	}

	public void Animate() {
		anim.SetTrigger ("Hit");
	}


	public void Destroy () {
		Destroy (gameObject);
	}

	public void boxType(){
		Debug.Log ("BoxBehaviour");
	}
}




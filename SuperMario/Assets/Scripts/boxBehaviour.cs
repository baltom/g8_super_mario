using UnityEngine;
using System.Collections;

public class boxBehaviour : MonoBehaviour {

	private bool hit = false;
	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	public void Hit () {
		anim.SetTrigger ("Hit");

	}


	public void Destroy () {
		Destroy (gameObject);
	}
	public void resetTrigger(string Trigger) {
		anim.ResetTrigger (Trigger);
	}
}

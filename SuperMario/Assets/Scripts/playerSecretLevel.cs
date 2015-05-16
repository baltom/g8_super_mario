using UnityEngine;
using System.Collections;

//Avhengi av hvilke metoder som blir aktivert vil Mario enten bevege seg horisontalt eller vertikalt i et hvis tidsrom.
//Dette er egentlig animasjonen av warpingen gjennom rør.
//Invoker også en metode fra GM som gjør at mario-objektet blir ødelagt og erstattet med et nytt et på en ny posisjon.

public class playerSecretLevel : MonoBehaviour {
	private bool entrance = false;
	private bool exit = false;
	private float speed = -1f;
	private float velocity;

	void FixedUpdate() {

		velocity = speed * Time.deltaTime;
		if (entrance){
			transform.position = new Vector2(transform.position.x, transform.position.y + velocity);
			GetComponent<Animator>().SetBool("idle", true);
		}

		if (exit) {
			transform.position = new Vector2(transform.position.x + velocity, transform.position.y);
			GetComponent<Animator>().SetBool("idle", false);
		}
	}
	
	public void secretLevel(){
		soundController.instance.playClip("smb_pipe.wav");
		Invoke("GMsecret", 2f);
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<BoxCollider2D> ().enabled = false;
		entrance = true;

	}

	public void secretLevelExit() {
		soundController.instance.playClip("smb_pipe.wav");
		Invoke ("GMsecretExit", 2f);
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<BoxCollider2D> ().enabled = false;
		exit = true;
		speed *= -1f;
	}

	public void pipeExit() {
		soundController.instance.playClip("smb_pipe.wav");
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<BoxCollider2D> ().enabled = false;
		entrance = true;
		if (speed < 0)
			speed *= -1f;
		Invoke ("unfreeze", 2f);
	}

	public void unfreeze() {
		GetComponent<Rigidbody2D> ().isKinematic = false;
		GetComponent<BoxCollider2D> ().enabled = true;
		entrance = false;
		exit = false;
	}

	public void GMsecret() {
		GM.instance.secretLevel ();
	}

	public void GMsecretExit() {
		GM.instance.secretExit ();
	}
}

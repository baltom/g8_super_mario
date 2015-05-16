using UnityEngine;
using System.Collections;

public class playerSecretLevel : MonoBehaviour {
	private bool entrance = false;
	private bool exit = false;
	private float speed = -1f;
	private float velocity;

	void FixedUpdate() {
		velocity = speed * Time.deltaTime;
		if (entrance){
			transform.position = new Vector2(transform.position.x, transform.position.y + velocity);
			Debug.Log ("ENTRANCE");
			GetComponent<Animator>().SetBool("idle", true);
		}

		if (exit) {
			transform.position = new Vector2(transform.position.x + velocity, transform.position.y);
			GetComponent<Animator>().SetBool("idle", false);
		}
	}

	public void secretLevel(){
		Invoke("GMsecret", 2f);
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<BoxCollider2D> ().enabled = false;
		entrance = true;

	}

	public void secretLevelExit() {
		Invoke ("GMsecretExit", 2f);
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<BoxCollider2D> ().enabled = false;
		exit = true;
		speed *= -1f;
	}

	public void pipeExit() {
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<BoxCollider2D> ().enabled = false;
		entrance = true;
		speed *= -1f;
		Invoke ("unfreeze", 2f);
	}

	public void unfreeze() {
		GetComponent<Rigidbody2D> ().isKinematic = false;
		GetComponent<BoxCollider2D> ().enabled = true;
		entrance = false;
	}

	public void GMsecret() {
		GM.instance.secretLevel ();
	}

	public void GMsecretExit() {
		GM.instance.secretExit ();
	}
}

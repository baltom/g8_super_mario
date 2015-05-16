using UnityEngine;
using System.Collections;

public class playerDeath : MonoBehaviour {
	public GameObject marioDeath;
	public Animator anim;
	private SpriteRenderer sr;
	private bool shrink;

	void damage(){
		//Sjekker om det er vanlig eller Super Mario
		if (!GM.instance.checkBig ()) {

			GM.instance.damageState ();
			marioDeath = Instantiate (marioDeath, new Vector3 (transform.position.x, transform.position.y, 0f), Quaternion.identity) as GameObject;
			Destroy (gameObject);

		} else if (!shrink){
			soundController.instance.playClip("smb_pipe.wav");

			anim.SetBool ("shrink", true);

			gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
			gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			gameObject.GetComponent<playerController>().enabled = false;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;

			//Invoke for å tilse at scriptet blir kjørt etter animasjonen.
			//Fant ut i ettertid at man kan legge inn scripts direkte i Animator.
			Invoke ("powerDown", 0.7f);
			shrink = true;
		}
	}

	public void powerDown(){
		GM.instance.powerDown();
	}
}

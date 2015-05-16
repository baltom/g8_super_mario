using UnityEngine;
using System.Collections;

public class playerDeath : MonoBehaviour {
	public GameObject marioDeath;
	public Animator anim;
	private float animSpeed = -1f;
	private SpriteRenderer sr;
	private bool shrink;

	void damage(){
		if (!GM.instance.checkBig ()) {
			GM.instance.damageState ();
			marioDeath = Instantiate (marioDeath, new Vector3 (transform.position.x, transform.position.y, 0f), Quaternion.identity) as GameObject;
			Destroy (gameObject);
		} else if (!shrink){
			anim.SetBool ("shrink", true);
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
			gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			gameObject.GetComponent<playerController>().enabled = false;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;

			Debug.Log ("PLAYER LARGE HIT");
			Invoke ("powerDown", 0.7f);
			shrink = true;
		}
	}

	public void powerDown(){
		Debug.Log ("POWER DOWN");
		GM.instance.powerDown();
	}
}

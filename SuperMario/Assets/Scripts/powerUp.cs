using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {
	public bool sideHit;


	public float speed = 100f;

	private Rigidbody2D mushroom;
	private SpriteRenderer sr;
	private Transform sideCheck;
	public Sprite lifeShroom;



	void Awake(){
		mushroom = GetComponent<Rigidbody2D> ();
		Invoke ("Speed", 1);
		sideCheck = transform.Find ("sideCheck");
		sr = GetComponentInChildren<SpriteRenderer> ();
		Debug.Log (gameObject.name);
		if (gameObject.name == "lifeShroom")
			spriteChange();
	}

	void Update (){
	sideHit = Physics2D.Linecast (transform.position, sideCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

	}

	void FixedUpdate() {
		if (sideHit) {
			mushroom.AddForce (new Vector2 (-speed, mushroom.velocity.y));
			sideHit = false;

		}
	}

	public void Speed() {
		mushroom.AddForce(new Vector2(speed, 0f));
	}

	public void spriteChange() {
		Debug.Log ("HEI");
		sr.sprite = lifeShroom;
	}

}

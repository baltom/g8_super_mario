using UnityEngine;
using System.Collections;

public class mushroom : MonoBehaviour {
	public bool lifeShroom;

	private bool sideHit;
	private bool active = false;
	private Transform sideCheck;
	private float speed;
	private float dir;
	public int value;

	void Awake() {
		dir = 1f;
		sideCheck = transform.Find ("sideCheck");
		Invoke ("move", 1f);
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("PowerUp"),  true);
	}

	void Update (){
		speed = 1f;
		speed = speed * Time.deltaTime;
		if (active){
			transform.position = new Vector2(transform.position.x + speed * dir, transform.position.y);
			sideHit = Physics2D.Linecast (transform.position, sideCheck.position, 1 << LayerMask.NameToLayer ("Ground")) || Physics2D.Linecast (transform.position, sideCheck.position, 1 << LayerMask.NameToLayer ("Box"));
		}
	}

	void FixedUpdate() {
		if (sideHit) {
			dir = -dir;
			sideHit = false;
		}
	}

	public void move() {
		GetComponent<BoxCollider2D> ().enabled = true;
		GetComponent<Rigidbody2D> ().isKinematic = false;
		active = true;
	}


}

using UnityEngine;
using System.Collections;

public class mushroom : powerUp {

	private bool sideHit;
	private bool active = false;
	private Rigidbody2D pwrUP;
	private Transform sideCheck;
	private float speed;
	private float dir;

	void Awake() {
		speed = 1.5f;
		dir = 1f;
		pwrUP = GetComponent<Rigidbody2D> ();
		sideCheck = transform.Find ("sideCheck");
		Invoke ("move", 1f);
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("PowerUp"),  true);
	}

	void Update (){
		Debug.Log (speed);
		speed = 2f;
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
		//pwrUP.AddForce(new Vector2(speed, 0f));
		active = true;
	}

}

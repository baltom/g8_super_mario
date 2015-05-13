using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	private Transform groundCheckLeft;
	private Transform groundCheckRight;
	private Transform topCheck;
	private Rigidbody2D Mario;
	RaycastHit2D boxHit;

	private float enemyBounce = 300f;

	void Awake() {
		groundCheckLeft = transform.Find ("groundCheckLeft");
		groundCheckRight = transform.Find ("groundCheckRight");	
		topCheck = transform.Find("topCheck");
		Mario = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		boxHit = Physics2D.Linecast(transform.position, topCheck.position, 1 << LayerMask.NameToLayer("Box"));
		if (boxHit) {
			boxHit.transform.SendMessage ("Hit");
			
		} else if (coll.gameObject.tag == "Enemy"){
			if (Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Enemy"))){
				coll.gameObject.SendMessage("death");
				Mario.AddForce(new Vector2(Mario.velocity.x, enemyBounce));
			} else {
				SendMessage("damage");
			}

		}
	}

}

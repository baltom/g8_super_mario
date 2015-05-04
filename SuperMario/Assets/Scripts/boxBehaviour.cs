using UnityEngine;
using System.Collections;

public class boxBehaviour : MonoBehaviour {

	private bool hit = false;
	private bool exhausted = false;

	public Sprite boxExhausted;
	public Transform mushroom;

	private Animator anim;
	public SpriteRenderer sr;

	private GameObject lifeShroom;
	
	void Awake(){
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer> ();
	}

	public void Animate() {
		anim.SetTrigger ("Hit");
	}

	public void Spawner(string tag) {
		if (!exhausted) {
			Animate ();

			if (tag == "boxCoin")
				boxCoin ();
			else if (tag == "boxMush")
				boxMush ();
			else if (tag == "boxLife")
				boxLife ();
			else if (tag == "boxHidden")
				boxHidden();
		}
	}

	public void Destroy () {
		Destroy (gameObject);
	}

	public void boxHidden(){
		BoxCollider2D boxColl = GetComponent<BoxCollider2D>();
		boxColl.enabled = true;
		boxMush ();
	}

	public void boxCoin() {
		spawnCoin ();
		exhaust();
	}

	public void boxLife() {
		
	}

	public void boxMush() {
		Invoke("spawnMushroom", 0.5f);
		exhaust ();
	}

	public void exhaust() {
		sr.sprite = boxExhausted;
		exhausted = true;
	}

	public void spawnCoin() {
	
	}

	public void spawnMushroom() {

		if (tag == "boxMush")
			Instantiate (mushroom, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1f, 0f), Quaternion.identity);
		else {

			lifeShroom = Instantiate (mushroom.gameObject, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1f, 0f), Quaternion.identity) as GameObject;
			lifeShroom.gameObject.SendMessage ("spriteChange");
		}
	}


	
}

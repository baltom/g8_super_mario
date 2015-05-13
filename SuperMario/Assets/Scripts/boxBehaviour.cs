using UnityEngine;
using System.Collections;

public class boxBehaviour : MonoBehaviour {

	public bool hit = false;
	public bool exhausted = false;

	private float x;
	private float y;

	public Sprite boxExhausted;
	public Transform contents;

	public Animator anim;
	public SpriteRenderer sr;

	private GameObject lifeShroom;
	
	void Awake(){
		setXY(0f, 1f);
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer> ();
	}

	public void Hit () {
		if (!exhausted) {
			animate();
			timedSpawn(0.5f);
			exhaust();
		}
	}

	public void timedSpawn (float timer) {
		Invoke ("spawn", timer);
	}

	public void setXY(float x, float y){
		this.x = x;
		this.y = y;
	}

	public void animate() {
		anim.SetTrigger ("Hit");
	}

	public void destroy () {
		Destroy (gameObject);
	}

	public virtual void exhaust() {
		sr.sprite = boxExhausted;
		exhausted = true;
	}
	
	public void spawn() {
			Instantiate (contents, new Vector3 (gameObject.transform.position.x + x, gameObject.transform.position.y + y, 0f), Quaternion.identity);
	}


	
}

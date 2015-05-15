using UnityEngine;
using System.Collections;

public class boxBehaviour : MonoBehaviour {

	public bool hit = false;
	public bool exhausted = false;
	public int value;

	private float x;
	private float y;

	public Sprite boxExhausted;
	public Transform contents;

	public AudioClip bumpSound;

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
		}else{
            soundController.instance.playClip("smb_bump.wav");
		}
	}

	public void timedSpawn (float timer) {
		Invoke ("spawn", timer);
	}

	public void setXY(float x, float y){
		this.x = x;
		this.y = y;
	}

	public void addScore(int value) {
		GM.instance.addScore(value);
	}

	public void animate() {
		gameObject.tag = "bumpBox";
		soundController.instance.playClip("smb_bump.wav");
		anim.SetTrigger ("Hit");
		Invoke ("revertTag", 1f);
	}

	public void destroy () {
		Destroy (gameObject);
	}

	public virtual void exhaust() {
		sr.sprite = boxExhausted;
		exhausted = true;
	}
	
	public void spawn() {
		GameObject coin = Instantiate (contents, new Vector3 (gameObject.transform.position.x + x, gameObject.transform.position.y + y, 0f), Quaternion.identity) as GameObject;
	}	

	public void revertTag(){
		gameObject.tag = "Box";
	}
}

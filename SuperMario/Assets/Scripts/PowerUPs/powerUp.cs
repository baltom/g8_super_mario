using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {
	
	private bool playerHit;

	public GUISkin gs;

	public int value;

	Vector3 pos = new Vector3(0,0,0);

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player"){
			pos = Camera.main.WorldToScreenPoint (transform.position);
			Rigidbody rb = transform.parent.gameObject.GetComponent<Rigidbody>();
			rb.AddForce(0,100,0);
			Destroy (transform.parent.gameObject, 0.7f);
			GM.instance.addCoin(value);
		}
	}
	void OnGUI(){
		pos.x = Camera.main.WorldToScreenPoint (transform.position).x;
		GUI.skin = gs;
		GUI.Label(new Rect(pos.x -20, Screen.height - pos.y -80,200,200), "200");
	}
}


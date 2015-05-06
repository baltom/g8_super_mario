using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour { 
	private bool finish;
	public GameObject target;
	public float xOffset = 3f;
	public float h;

	private float temp;


	void Awake () {
		findPlayer ();
	}

	void Update() {
		if (!finish) {
			h = Input.GetAxis ("Horizontal");
			if (target.transform.position.x > transform.position.x - xOffset)
				transform.position = new Vector3 (target.transform.position.x + xOffset,
		                                  transform.position.y,
		                                  transform.position.z);
			temp = target.transform.position.x;
		}

		if (gameObject.transform.position.x > 196.8f) {
			gameObject.transform.position = new Vector3(197f, gameObject.transform.position.y, -5f);
			finish = true;
		}
	}

	public void findPlayer() {
		target = GameObject.FindGameObjectWithTag ("Player");
	}
}
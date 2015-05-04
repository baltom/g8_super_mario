using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour { 

	public GameObject target;
	public float xOffset = 3f;
	public float h;

	private float temp;


	void Awake () {
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update() {

		h = Input.GetAxis ("Horizontal");
		if (target.transform.position.x > transform.position.x - xOffset)
			transform.position = new Vector3 (target.transform.position.x + xOffset,
		                                  transform.position.y,
		                                  transform.position.z);
		temp = target.transform.position.x;
	}
}
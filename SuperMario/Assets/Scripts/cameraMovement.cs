﻿using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour { 
	public bool finish = false;
	public bool secret = false;

	public GameObject target;
	public GameObject temp;
	public float xOffset = 3f;
	public float h;

	void Awake () {
		findPlayer();
	}

	void Update() {
		//Debug.Log (target);
		if (target == null) {
			findPlayer();
		}
		if (!finish && target != null && !secret) {
			
			h = Input.GetAxis ("Horizontal");
			if (target.transform.position.x > transform.position.x - xOffset)
				transform.position = new Vector3 (target.transform.position.x + xOffset,
		                                  transform.position.y,
		                                  transform.position.z);
		}

		if (gameObject.transform.position.x > 196.8f) {
			gameObject.transform.position = new Vector3(197f, gameObject.transform.position.y, -5f);
			finish = true;
		}
	}

	public void findPlayer() {
		target = GameObject.FindWithTag("Player");
	}

	public void secretLevel() {
		if (!secret)
			transform.position = new Vector3 (152f, -13.5f, transform.position.z);
		else
			transform.position = new Vector3 (160f, 5.5f, transform.position.z);

		secret = !secret;

	}


}
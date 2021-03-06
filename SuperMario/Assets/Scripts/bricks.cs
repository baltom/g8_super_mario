﻿using UnityEngine;
using System.Collections;

public class bricks : boxBehaviour {

	public AudioClip breakSound;
	public GameObject break_topRight;
	public GameObject break_topLeft;
	public GameObject break_bottomRight;
	public GameObject break_bottomLeft;

	new void Hit  () {

		//Sjekker om Mario er Super Mario eller ikke.
		if (!GM.instance.checkBig ()) {
			soundController.instance.playClip("smb_bump.wav");
			animate ();
		} else {
		//Dødelig tag for fiender
			gameObject.tag = "bumpBox";
			soundController.instance.playClip("smb_breakblock.wav");
			Destroy(gameObject);

		//Instantierer fire objekter som simulerer en framgentering av den knuste boksen.
			GameObject breakTopRight;
			breakTopRight = Instantiate (break_topRight, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), Quaternion.identity) as GameObject;
			breakTopRight.GetComponent<Rigidbody2D>().AddForce (new Vector2(200f, 600f));

	
			GameObject breakTopLeft;
			breakTopLeft = Instantiate (break_topLeft,  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), Quaternion.identity) as GameObject;
			breakTopLeft.GetComponent<Rigidbody2D>().AddForce (new Vector2(-200f, 600f));

			GameObject breakBottomRight;
			breakBottomRight = Instantiate (break_bottomRight, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), Quaternion.identity) as GameObject;
			breakBottomRight.GetComponent<Rigidbody2D>().AddForce(new Vector2(200f, 200f));

			GameObject breakBottomLeft;
			breakBottomLeft = Instantiate (break_bottomLeft,  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), Quaternion.identity) as GameObject;
			breakBottomLeft.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, 200f));
			addScore(value);
		}
	}


}

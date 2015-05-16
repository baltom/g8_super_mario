using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {
	public int value;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Player"){
			Destroy (gameObject);
			soundController.instance.playClip ("smb_coin.wav");
			GM.instance.addCoin (value);
		}

	}
}

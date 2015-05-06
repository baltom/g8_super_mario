using UnityEngine;
using System.Collections;

public class playerDeath : MonoBehaviour {
	public GameObject marioDeath;
	void death(){
		GameObject clone;
		marioDeath = Instantiate(marioDeath, new Vector3 (transform.position.x, transform.position.y, 0f), Quaternion.identity) as GameObject;
		Destroy(gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class playerDeath : MonoBehaviour {
	public GameObject marioDeath;
	public Animator anim;

	void death(){
		if (!GM.instance.checkBig()){
			GM.instance.subtractLives();
			marioDeath = Instantiate(marioDeath, new Vector3 (transform.position.x, transform.position.y, 0f), Quaternion.identity) as GameObject;
			Destroy(gameObject);
		} else {
			anim.SetTrigger("death");
			anim.speed = -1f;
			gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			gameObject.GetComponent<playerController>().enabled = false;
			
			
			Invoke ("powerDown", 1f);
		}
	}

	public void powerDown(){
		GM.instance.powerDown();
	}
}

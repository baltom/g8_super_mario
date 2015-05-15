using UnityEngine;
using System.Collections;

public class GoombaScript : MonoBehaviour {

    Vector2 dir;
    bool dead = false;

    
	// Use this for initialization
	void Start () {
        dir = -Vector2.right;
    }
	
	// Update is called once per frame
    void Update() {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
       	if (!dead) {
			transform.position = Vector2.MoveTowards (transform.position, pos + (dir * 1f), Time.deltaTime * 1f);
		}
        Vector2 rayPos = new Vector2(transform.position.x + (dir.x * 0.51f), transform.position.y - 0.4f);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, dir, 0.01f);
		if (hit.transform != null && !hit.transform.gameObject.tag.Equals("Player") && !dead && !hit.transform.gameObject.tag.Equals("MainCamera")) {
            toggleDirection();
        }
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(rayPos.x - (dir.x * 1f), rayPos.y), -dir, 0.01f);
        if (hit.collider != null && hit.transform.gameObject.tag.Equals("Shell") || hit2.collider != null && hit2.transform.gameObject.tag.Equals("Shell")) {
            dir = Vector2.zero;
            transform.localScale = new Vector3(1, -1);
            transform.position = new Vector3(transform.position.x, transform.position.y);
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1));
            Component.Destroy(transform.GetComponent<BoxCollider2D>());
            dead = true;
        }
		//Debug.Log (GetComponent<Rigidbody2D> ().velocity.x);
	}

    private void toggleDirection() {
        dir *= -1;
    }

    void death(){
        soundController.instance.playClip("smb_stomp.wav");
            GameObject deadArt = transform.Find("dead").gameObject;
            deadArt.SetActive(true);
            deadArt.transform.SetParent(null);
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(deadArt, 2);
			soundController.instance.playClip("smb_stomp.wav");
    }

	void deathByBump(){
		Destroy (gameObject, 10);
		GetComponent<BoxCollider2D> ().enabled = false;
		transform.Rotate (0f, 0f, 180f);
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (75f * Mathf.Sign (dir.x) , 200f));
		soundController.instance.playClip("smb_stomp.wav");
		dead = true;
	}

	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "bumpBox")
			deathByBump ();
	}



}

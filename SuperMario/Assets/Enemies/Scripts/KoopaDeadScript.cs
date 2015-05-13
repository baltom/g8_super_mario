using UnityEngine;
using System.Collections;

public class KoopaDeadScript : MonoBehaviour {

    bool shot = false;
    Vector2 dir;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (shot) {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, pos + (dir * 10f), Time.deltaTime * 10);
            Vector2 rayPos = new Vector2(transform.position.x + (dir.x * 0.51f), transform.position.y - 0.4f);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, dir, 0.01f);
            if (hit.transform != null && !hit.transform.gameObject.tag.Equals("Enemy")) {
                toggleDirection();
            }
            RaycastHit2D hit2 = Physics2D.Raycast(rayPos, -dir, 0.01f);
            if (hit.collider != null && hit.transform.gameObject.tag.Equals("Player") || hit2.collider != null && hit2.transform.gameObject.tag.Equals("Player")) {
                //Player.die;
            }
        }
	}

    private void toggleDirection() {
        if (dir == -Vector2.right) {
            dir = Vector2.right;
        } else {
            dir = -Vector2.right;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            if (collision.transform.position.x > transform.position.x) {
                dir = -Vector2.right;
            } else {
                dir = Vector2.right;
            }
			shot = true;
			gameObject.tag = "Shell";
        }
       
    }
}

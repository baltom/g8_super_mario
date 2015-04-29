using UnityEngine;
using System.Collections;

public class KoopaScript : MonoBehaviour {

    Vector2 dir;
    bool dead = false;

	// Use this for initialization
	void Start () {
        dir = -Vector2.right;
    }
	
	// Update is called once per frame
    void Update() {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, pos + (dir * 0.1f), Time.deltaTime * 0.5f);
        Vector2 rayPos = new Vector2(transform.position.x + (dir.x * 0.08f), transform.position.y - 0.04f);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, dir, 0.01f);
        if (hit.transform != null && !hit.transform.gameObject.tag.Equals("Player") && !dead) {
            toggleDirection();
        }
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(rayPos.x - (dir.x * 0.16f), rayPos.y), -dir, 0.01f);
        if (hit.collider != null && hit.transform.gameObject.tag.Equals("Shell") || hit2.collider != null && hit2.transform.gameObject.tag.Equals("Shell")) {
            dir = Vector2.zero;
            transform.localScale = new Vector3(transform.localScale.x, -1);
            transform.position = new Vector3(transform.position.x, transform.position.y);
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1));
            Component.Destroy(transform.GetComponent<BoxCollider2D>());
            dead = true;
        }
        Vector2 rayPosUp = new Vector2(pos.x, pos.y + 0.16f);
        RaycastHit2D hitUp = Physics2D.Raycast(rayPos, Vector2.up, 0.01f);
        if (hitUp.collider != null && hitUp.transform.gameObject.tag.Equals("Player") || Input.GetKey(KeyCode.I)) {
            GameObject deadArt = transform.Find("Shell").gameObject;
            deadArt.SetActive(true);
            deadArt.transform.SetParent(null);
            GameObject.Destroy(this.gameObject);
        }
	}

    private void toggleDirection() {
        if (dir == -Vector2.right) {
            dir = Vector2.right;
            flip();
        } else {
            dir = -Vector2.right;
            flip();
        }
    }

    private void flip() {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            //player.die;
        }
    }
}

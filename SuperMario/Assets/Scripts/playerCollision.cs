using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	private Transform groundCheckLeft;
	private Transform groundCheckRight;
	private Transform topCheck;
	private Rigidbody2D Mario;
	RaycastHit2D boxHit;

    public GameObject uiPopup;

	private float enemyBounce = 300f;
    private int addScore = 100;

	void Awake() {
		groundCheckLeft = transform.Find ("groundCheckLeft");
		groundCheckRight = transform.Find ("groundCheckRight");	
		topCheck = transform.Find("topCheck");
		Mario = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate() {
        //Reset score når mario treffer bakken igjen
        if (Mario != null && Mario.GetComponent<playerController>() != null) { 
            if (Mario.GetComponent<playerController>().isGrounded()) addScore = 100;
        }
    }

	void OnCollisionEnter2D(Collision2D coll) {
		boxHit = Physics2D.Linecast(transform.position, topCheck.position, 1 << LayerMask.NameToLayer("Box"));
		if (boxHit) {
			boxHit.transform.SendMessage ("Hit");
			
		} else if (coll.gameObject.tag == "Enemy"){
			if (Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Enemy"))){
				coll.gameObject.SendMessage("death");
				Mario.AddForce(new Vector2(Mario.velocity.x, enemyBounce));
                GM.instance.addScore(addScore);
                Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                Vector2 pos = cam.WorldToViewportPoint(coll.gameObject.transform.position);
                pos = new Vector2(pos.x + 0.01f, pos.y+0.02f);
                uiController.instance.setPopup(addScore, pos);
                
                addScore += 100;

			} else {
				SendMessage("damage");
			}

		}
	}

    void OnTriggerEnter2D(Collider2D coll)  {
		if (coll.gameObject.tag == "finish")
        {
			GameObject flagPole = coll.gameObject;
			GM.instance.addScore (finishScore(flagPole));
            GM.instance.gameWon();
        }
    }

	int finishScore(GameObject flagPole) {
		int flagScore;

		if (Mario.position.y >= 9)
			flagScore = 5000;
		else
			flagScore = (Mathf.RoundToInt (Mario.position.y) * 250);
		Debug.Log (flagScore);
		return flagScore;
		
	}

}

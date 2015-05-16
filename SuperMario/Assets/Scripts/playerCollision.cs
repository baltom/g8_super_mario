using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	private Transform groundCheckLeft;
	private Transform groundCheckRight;
	private Transform topCheck;
	private Rigidbody2D Mario;
	private bool invulnerable;
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
		//Sjekker om Mario treffer en boks. Bruker Linecast for at man kun skal kunne treffe 1 boks om gangen.
		boxHit = Physics2D.Linecast(transform.position, topCheck.position, 1 << LayerMask.NameToLayer("Box"));

		if (boxHit) {
			//Sender bedskjed til boksen om at den har blitt truffet
			boxHit.transform.SendMessage ("Hit");
			
		} else if (coll.gameObject.tag == "Enemy"){
			//Overlap area under Mario sjekker om fienden er under. Hvis ikke dør Mario.
			if (Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Enemy"))){
				//Sender bedskjed til fiendeobjektet at det er dødt.
				coll.gameObject.SendMessage("death");

				//Bounce
				Mario.AddForce(new Vector2(Mario.velocity.x, enemyBounce));

				//Legger til score
                GM.instance.addScore(addScore);

				//Legger til score labels
                Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                Vector2 pos = cam.WorldToViewportPoint(coll.gameObject.transform.position);
                pos = new Vector2(pos.x + 0.01f, pos.y+0.02f);
                uiController.instance.setPopup(addScore, pos);
                
                addScore += 100;

			} else {
				//Mario tar skade
				SendMessage("damage");
			}

		}
	}

    void OnTriggerEnter2D(Collider2D coll)  {

		//Mario vinner
		if (coll.gameObject.tag == "finish")
        {
			GameObject flagPole = coll.gameObject;
			GM.instance.addScore (finishScore(flagPole));
            GM.instance.gameWon();
        }
    }

	int finishScore(GameObject flagPole) {
		int flagScore;

		//Hvis Mario treffer på toppen
		if (Mario.position.y >= 9)
			flagScore = 5000;

		//Hvis Mario treffer noe annet rundes det av til int og ganges med 250.
		else
			flagScore = (Mathf.RoundToInt (Mario.position.y) * 250);

		return flagScore;
		
	}

	public void damageTimer() {
		//Dette scriptet gjør Mario halvgjennomsiktig og uskadelig og tilbake til vanlig igjen.
		invulnerable = !invulnerable;
		if (invulnerable)
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0.5f);
		else
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1f);
	}

}

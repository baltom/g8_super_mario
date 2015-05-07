using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	private bool jump = false;
	private bool facingRight = true;
	private bool grounded = true;
	private bool jumpAccelerate = false;
	private bool sprint = false;
	private bool idle = true;
	private bool turn = false;

	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	public Transform topCheck;

	public float counter = 0f;
	public float h;
	public float jumpAccel = 20f;
	public float moveForce = 10f;
	public float airForce = 5f;
	public float maxSpeed = 7f;
	public float minSprint = 7f;
	public float maxSprint = 10f;
	public float jumpForce = 400f;	
	public float adjuster = 0.5f;
	public float temp;
	
	public Rigidbody2D Mario;

	public Animator anim;


	void Awake () {
	//Finner bakkesjekkeren. Empty gameObject.
		anim = GetComponent<Animator>();
		groundCheckLeft = transform.Find ("groundCheckLeft");
		groundCheckRight = transform.Find ("groundCheckRight");	

	//Initialiserer Rigidbody
		Mario = GetComponent<Rigidbody2D>();
	}

	
	void Update () {
	
	//Sjekker om spilleren står på en bakke. Bakkesjekkeren er plassert under spilleren. To tomme gameobjects under spilleren sjekker om de overlapper gameobjects på lagmasken "ground".
	//Bruker OverlapArea i stedet for linecast ettersom linecast kun sjekker et punkt og dermed vil returnere false om spilleren står helt ytterst på en kant.
		grounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Box"));	
	
	
	//BUTTON JUMP
		if (Input.GetButtonDown ("Jump") && grounded) {
			Mario.drag = 0f;
			jump = true;
			//Om bruker fortsetter å holde knappen inne vil Mario hoppe høyere.
			jumpAccelerate = true;
			jumpAccel = 27f;

		}

	//BUTTON UP JUMP. 
	//Om bruker slipper hoppeknappen stopper hoppeakselerasjonen
		if(Input.GetButtonUp ("Jump"))
			jumpAccelerate = false; 
	

	//Button Sprint
		if (Input.GetButton ("Sprint")) //LSHIFT er satt opp som standard. Kan endres av bruker.
			sprint = true;
		else 
			sprint = false;	
	}
	
	void FixedUpdate() {

		//H = Brukerens input basert på hans keybinds i Unity. Følger horizontal-input. (0 = ingen input. 1 = Høyre. -1 = Venstre.)
		h = Input.GetAxis("Horizontal");
		//GROUNDED-BOOL. BRUKES AV NOEN AV ANIMASJONENE SOM PREMISSER
		anim.SetBool("grounded", grounded);
		//SNU-ANIMASJON
		anim.SetBool ("turn", turn);
		//IDLE-ANIMASJON
		anim.SetBool ("idle", idle);

		//Hvis spilleren står på bakken
		if (grounded) {

			//FLIPPE SPRITE
			//Flippe spilleren når han/hun står mot venstre
			if (h > 0 && !facingRight) {
				Flip ();
				
			
			//Flippe spilleren om han/hun står mot høyre.
			} else if (h < 0 && facingRight) {
				Flip ();
			}

			//SNU-ANIMASJON
			//Hvis Mario peker en annen retning enn den retningen han har fart i så spilles snu-animasjonen av.
			if (Mario.velocity.x > 1f && !facingRight) {
				turn = true;
			} else if (Mario.velocity.x < -1f && facingRight) {
				turn = true;
			} else {
				turn = false;
			}

			//SPRINT
			if (sprint) {
				maxSpeed += adjuster;
				if (maxSpeed >= maxSprint)
					maxSpeed = maxSprint;
			} else if (maxSpeed > minSprint)
				maxSpeed -= adjuster;

			//GENERELL BEVEGELSE X-AKSEN

			//Hvis vi er under max-hastigheten
			if (h * Mario.velocity.x < maxSpeed) {
				Mario.AddForce (Vector2.right * h * moveForce);
			}

			//Hvis ingen input inntreffer
			if (h == 0f) {
				//Hvis Mario har en større hastighet enn vanlig sprint-hastighet. Dette gjør at Mario sklir etter at man sprinter.
				if (Mario.velocity.x > 7f || Mario.velocity.x < -7f)
					Mario.drag = 2f;
				else 
					//Ville heller lage egne koder for friksjon. Ettersom den innebygde friksjonen i Unity på materials gjorde at mario stoppet helt opp etter et hopp.
					Mario.drag = 10f;
				//Forteller animator at den skal spille av idle-animasjonen.
				idle = true;
			} else {
				//Forteller animator at den skal spille av springe-animasjonen.
				idle = false;
				//Enklere å justere hastighet på springingen når man ikke har noe friksjon når man løper. 
				Mario.drag = 0f;
			}
		
		//!GROUNDED
		} else {
			//Ingen friksjon i lufta.
			Mario.drag = 0f;

			//LUFTKONTROLL
			//Man har mindre kontroll i lufta enn på bakken. Prøver å etterligne hvordan dette fungerer i Mario på NES.
			Mario.AddForce (Vector2.right * h * airForce);

			//For å forsikre oss om at det ikke spilles av noen snu-animasjon når man hopper.
			turn = false;
		}

		//Limit movespeed
		if(Mathf.Abs(Mario.velocity.x) > maxSpeed)
			Mario.velocity = new Vector2(Mathf.Sign(Mario.velocity.x) * maxSpeed, Mario.velocity.y);

		//HOPP
		if (jump) {
			Mario.drag = 0f;
			Mario.AddForce(new Vector2(Mario.velocity.x, jumpForce));
			jump = false;
		}

		//HOPPAKSELERASJON
		if (jumpAccelerate) {
			Mario.AddForce(new Vector2(0f, jumpAccel));
			jumpAccel -= 1;
			

		}
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight; 
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}


}

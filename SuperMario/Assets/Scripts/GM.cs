using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	bool big = false;
	bool dead = false;

	private int lives = 3;
	private int time;
	private int score;

	private float x;
	private float y;


	private int coins;
//>>>>>>> origin/master
	public float spawn = 155;

	public GameObject Mario;
	public GameObject MarioLarge;

	private GameObject MarioClone;

	public static GM instance = null;

	private uiController ui;

	void Awake() {
		time = 400;
		score = 0;
		coins = 0;

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		spawnMario(Mario, spawn, 1f);

		//Fiende og powerups
		Physics2D.IgnoreLayerCollision(11, 12,  true);

		//Fiende og kamera
		Physics2D.IgnoreLayerCollision(11, 14,  true);

		//Kamera og powerups
		Physics2D.IgnoreLayerCollision(14, 12,  true);

		//Spiller og powerups. Bruker trigger. Hindrer at powerups bremser opp spillerobjektet.
		Physics2D.IgnoreLayerCollision(15, 12,  true);

		ui = GameObject.FindGameObjectWithTag("ui").GetComponent<uiController>();;
	
		InvokeRepeating ("updateTimer", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		//time -= 1;

	}

	void updateTimer() {
		time -= 1;
		ui.setTime (time);
	}

	public void marioGrow() {
		Debug.Log("GROW");
		destroyClone();
		spawnMario(MarioLarge, x, y + 0.5f);
		big = true;
	}

	public void powerDown() {
		big = false;
		destroyClone();
		spawnMario(Mario, x, y);
	}

	public bool checkBig() {
		return big;
	}

	public void destroyClone(){
		x = getX();
		y = getY();
		Destroy (MarioClone);
	}

	public float getX(){
		x = MarioClone.transform.position.x;

		return x;
	}

	public float getY(){
		y = MarioClone.transform.position.y;
		return y;
	}

	public void spawnMario(GameObject MarioPrefab, float x, float y) {
		MarioClone = Instantiate (MarioPrefab, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
	}

	public void addCoin(int value) {
		addScore (value);
		coins += value;
		ui.setCoins (coins);
	}

	public void addScore(int value) {
		score += value;
		ui.setScore (score);
	}

	public void addLives(){
		lives += 1;
	}

	public void subtractLives() {
		Debug.Log(lives);
		if (deathCheck ()) {
			Debug.Log("GAME OVER");
			MarioClone.SendMessage("gameOver");
			gameOver ();
		} else {
			Debug.Log("LIFE DOWN");
			lives -= 1;
			Invoke("restart", 3f);
		}
	}

	public bool deathCheck() {

		if (lives == 0)
			dead = true;

		return dead;
	}

	public void restart() {
		Debug.Log("RESTART");
		Application.LoadLevel(Application.loadedLevel);
	}

	public void gameOver() {
	
	}

}

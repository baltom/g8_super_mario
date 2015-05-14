using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	bool big = false;
	bool dead = false;
	bool timesUp = false;

	private int lives = 3;
	private int time;
	private int score;

	private float x;
	private float y;

	private int coins;
	public float spawn = 155;

	public GameObject lifeManager;
	public GameObject Mario;
	public GameObject MarioLarge;

	private GameObject MarioClone;

	public static GM instance = null;

    public AudioClip fasterThemeSound;

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

		ui = GameObject.FindGameObjectWithTag("ui").GetComponent<uiController>();
	
		InvokeRepeating ("updateTimer", 0, 0.5f);
	}

	void updateTimer() {
		time -= 1;
		ui.setTime (time);
		if (time == 100) {
			soundController.instance.setMainTheme(fasterThemeSound);
		} else if (time <= 0) {
			timesUp = true;
			damageState();
			CancelInvoke("updateTimer");
            time = 0;
		}
	}

	public void marioGrow() {
		Debug.Log("GROW");
		destroyClone();
		spawnMario(MarioLarge, x, y + 0.5f);
		big = true;
        soundController.instance.playClip("smb_powerup.wav");
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
		coins++;
		ui.setCoins (coins);
        soundController.instance.playClip("smb_coin.wav");
	}

	public void addScore(int value) {
		score += value;
		ui.setScore (score);
	}

	public void oneUp(){
        lives++;
		lifeManager.SendMessage("addlives");
	}

	public void damageState() {
		Debug.Log(lives);
		soundController.instance.stopMainTheme();
		if (deathCheck ()) {
			Debug.Log("GAME OVER");
			MarioClone.SendMessage("gameOver");
			soundController.instance.playClip ("smb_gameover.wav");
			gameOver ();
		} else {
			Debug.Log("LIFE DOWN");
            lives--;
			lifeManager.SendMessage("subtractLives");
			Invoke("restart", 3f);
			soundController.instance.playClip ("smb_mariodie.wav");
		}
	}

	public bool deathCheck() {

		if (lives == 0)
			dead = true;

		return dead;
	}

	public void restart() {
		Debug.Log("RESTART");
		Application.LoadLevel(1);
	}

	public void gameOver() {
	
	}

    public int getLives()
    {
        return lives;
    }

}

using UnityEngine;
using System.Collections;
// GM tar seg av mye av kommunikasjon mellom objektene og instantiering og ødelegging av Mario-objektet.
public class GM : MonoBehaviour {

	bool big = false;

	private int time;
	private int score;

	private float x;
	private float y;

	private int coins;
	public float spawn = 155;

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

    void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
            ui.setScore(score);
        }
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
            ui.setCoins(coins);
        }
    }

	void updateTimer() {
		time -= 1;
		ui.setTime (time);
		if (time == 100) {
			soundController.instance.setMainTheme(fasterThemeSound);
		} else if (time <= 0) {
			damageState();
			CancelInvoke("updateTimer");
            time = 0;
		}
	}

	//Sender Mario til den hemmelige verden
	public void secretLevel() {
		MarioClone.transform.position = new Vector2 (145f, -7f);
		MarioClone.SendMessage ("unfreeze");
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("secretLevel");
	}

	//Sender Mario ut av den hemmelige verden.
	public void secretExit() {
		MarioClone.SendMessage ("unfreeze");
		if(checkBig())
			MarioClone.transform.position = new Vector2 (162.5f, 1.5f);
		else
			MarioClone.transform.position = new Vector2 (162.5f, 1f);

		MarioClone.gameObject.SendMessage ("pipeExit");
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("secretLevel");
	}

	//Når mario plukker opp en sopp
	public void marioGrow() {
		destroyClone();

		spawnMario(MarioLarge, x, y + 0.5f);
		big = true;

        soundController.instance.playClip("smb_powerup.wav");
	}

	//Når Mario mister Super
	public void powerDown() {
		big = false;

		destroyClone();

		spawnMario(Mario, x, y);
		MarioClone.SendMessage ("damageTimer");

		//Dette gjør at Mario ikke kan ta skade 
		Physics2D.IgnoreLayerCollision(15, 11,  true);

		//Invoke for å slå av uovervinneligheten
		Invoke ("damageTimer", 2f);
	}

	//Gjør at Mario kan ta skade igjen etter å ha tatt skade.
	public void damageTimer() {
		MarioClone.SendMessage ("damageTimer");
		Physics2D.IgnoreLayerCollision(15, 11,  false);
	}

	//For å sjekke om Mario er Super Mario eller ikke.
	public bool checkBig() {
		return big;
	}

	//Ødelegger Mario-objektet
	public void destroyClone(){
		x = getX();
		y = getY();
		Destroy (MarioClone);
	}

	//Finner og returnerer Mario-klonen sin posisjon i X-aksen
	public float getX(){
		x = MarioClone.transform.position.x;
		return x;
	}

	//Finner og returnerer Mario-klonen sin posisjon i Y-aksen
	public float getY(){
		y = MarioClone.transform.position.y;
		return y;
	}

	//Instantierer Mario basert på hvilke inputs man gir. Dette gjør at man kan bruke samme metoden til forskjellig spawning.
	public void spawnMario(GameObject MarioPrefab, float x, float y) {
		MarioClone = Instantiate (MarioPrefab, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
	}

	//Legger til Score og Pengeantall	
	public void addCoin(int value) {
		addScore (value);
		coins++;
		ui.setCoins (coins);
        soundController.instance.playClip("smb_coin.wav");
        PlayerPrefs.SetInt("coins", coins);
	}

	//Legger til Score (value er en public int på hver av objektene som plukkes opp).
	public void addScore(int value) {
		score += value;
		ui.setScore (score);
        PlayerPrefs.SetInt("score", score);
	}

	//Ekstraliv
	public void oneUp(){
		lifeManager.instance.addLives();
	}

	//Når mario tar skade
	public void damageState() {

		soundController.instance.stopMainTheme();
		lifeManager.instance.subtractLives();

       	if (deathCheck()) {
        	gameOver();
     	}

		Invoke("restart", 3f);
		soundController.instance.playClip ("smb_mariodie.wav");
	}

	public bool deathCheck() {
        return lifeManager.instance.getLives() <= 0;
	}

	public void restart() {
		Application.LoadLevel(1);
	}

    public void gameWon()
    {
        destroyClone();
        soundController.instance.stopMainTheme();
        soundController.instance.playClipAt("smb_stage_clear.wav", new Vector3(204, 1, 0));
        InvokeRepeating("finalScoreUpdate", 0f, .05f);
    }

    public void finalScoreUpdate()
    {
        if (time > 0) { 
            time--;
            ui.setTime(time);
            addScore(50);
           soundController.instance.playClipAt("smb_coin.wav", new Vector3(204, 1, 0), 0.5f);
        } else {
            time = 0;
            ui.setTime(0);
            CancelInvoke();
            PlayerPrefs.SetInt("topScore", score);
            Application.LoadLevel(0);
        }
    }

	public void gameOver() {
        MarioClone.SendMessage("gameOver");
        Application.LoadLevel(3);
	}

}

using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	private int lives;
	private int time = 300;
	private int score;
	public float spawn = 155;

	public GameObject Mario;
	public GameObject MarioLarge;

	public Camera MainCamera;

	private GameObject MarioClone;

	public static GM instance = null;

	void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		spawnMario(Mario, spawn, 1f);

		Physics2D.IgnoreLayerCollision(11, 12,  true);
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= 1;
	}

	public void marioGrow() {
		float x = MarioClone.transform.position.x;
		float y = MarioClone.transform.position.y;

		Destroy (MarioClone);

		spawnMario(MarioLarge, x, y);

		MainCamera.SendMessage ("invokePlayer");
	}

	public void spawnMario(GameObject MarioPrefab, float x, float y) {
		MarioClone = Instantiate (MarioPrefab, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
	}

	public void addCoin(int value) {
		addScore (value);
	}

	public void addScore(int value) {
		score += value;
	}

	public void addLives(){
		lives += 1;
	}

	public void subtractLives() {
		if (deathCheck ()) 
			gameOver ();
		else
			lives -= 1;
		restart ();
	}

	public bool deathCheck() {
		bool dead = new bool ();

		if (lives == 0)
			dead = true;

		return dead;
	}

	public void restart() {
		
	}

	public void gameOver() {
	
	}

}

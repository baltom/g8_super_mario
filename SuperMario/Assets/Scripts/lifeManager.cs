using UnityEngine;
using System.Collections;

public class lifeManager : MonoBehaviour {
	private int lives = 3;
	// Use this for initialization
	void Awake() {
		Object.DontDestroyOnLoad(gameObject);
	}

	void addLives() {
		lives++;
	}

	void subtractLives() {
		lives--;
	}

	int getLives() {
		return lives;
	}


}

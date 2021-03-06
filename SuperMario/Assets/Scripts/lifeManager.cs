﻿using UnityEngine;
using System.Collections;

public class lifeManager : MonoBehaviour {
	public int lives = 3;
    public static lifeManager instance = null;
	// Use this for initialization
	void Awake() {
        if (instance == null)
            instance = this;

        if (PlayerPrefs.HasKey("lives"))
        {
            lives = PlayerPrefs.GetInt("lives");
        }
		Object.DontDestroyOnLoad(gameObject);
		//Debug.Log (lives);
	}

	public void addLives() {
		lives++;
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.Save();
	}

	public void subtractLives() {
        if (lives > 0) { 
		    lives--;
            PlayerPrefs.SetInt("lives", lives);
            PlayerPrefs.Save();
        }
	}

	public int getLives() {
		return lives;
	}


}

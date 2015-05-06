using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	private int lives;
	private int time = 300;
	private int score;

	public static GM instance = null;

	public GameObject Mario;

	void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		Physics2D.IgnoreLayerCollision(11, 12,  true);
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= 1;
	}

	public void powerUpManager (int life) {
		if (life == 1 || life == -1) {
			lives += life;
			Debug.Log(lives);
		} else if (life == 2)
			Debug.Log("Mario GROW!");
		else 
			Debug.Log("FlowerPower");

		
	}
}

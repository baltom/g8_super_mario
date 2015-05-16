using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour { 
	public bool finish = false;
	public bool secret = false;

	public GameObject target;
	public GameObject temp;
	public float xOffset = 3f;
	public float h;
	
	void Awake () {
		//Finner spillerobjektet
		findPlayer();
	}

	void Update() {
		//Hvis kameraet ikke har noe target skal det finne spilleren på nytt.
		//Dette er til hendelser der mario-objektet blir ødelagt for å erstattes med Super Mario.
		if (target == null) {
			findPlayer();
		}

		if (!finish && target != null && !secret) {
			if (target.transform.position.x > transform.position.x - xOffset)
				//Finner Mario sin posisjon og er alltid xOffset unna han. Kan ikke gå bakover eller oppover.
				transform.position = new Vector3 (target.transform.position.x + xOffset, transform.position.y, transform.position.z);
		}

		if (gameObject.transform.position.x > 196.8f) {
			//Hvis kameraet er kommet til slutten fryser det.
			gameObject.transform.position = new Vector3(197f, gameObject.transform.position.y, -5f);
			finish = true;
		}
	}

	public void findPlayer() {
		target = GameObject.FindWithTag("Player");
	}

	public void secretLevel() {
		//Når secretlevel blir aktivert flytter kamera seg til levelen og fryser der til Mario warper ut igjen.
		if (!secret)
			transform.position = new Vector3 (152f, -13.5f, transform.position.z);
		else
			transform.position = new Vector3 (160f, 5.5f, transform.position.z);

		secret = !secret;

	}


}
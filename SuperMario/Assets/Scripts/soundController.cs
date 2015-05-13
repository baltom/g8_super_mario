using UnityEngine;
using System.Collections;

public class soundController : MonoBehaviour {

	public static soundController instance = null;

	private AudioSource mainTheme;
	public AudioClip bumpSound;

	public void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		mainTheme = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource> ();
	}

	public void playSound(AudioClip sound) {
		AudioSource.PlayClipAtPoint(sound, new Vector3(GM.instance.getX(), GM.instance.getY (), 0));
	}

	public void setMainTheme(AudioClip sound) {
		mainTheme.Stop ();
		mainTheme.clip = sound;
		mainTheme.Play ();
	}

	public void stopMainTheme() {
		mainTheme.Stop ();
	}

}

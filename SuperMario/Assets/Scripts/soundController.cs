using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class soundController : MonoBehaviour {

	public static soundController instance = null;

    private string soundDir = "./Sounds"; //Dir til lyd filer når spillet er en exe
    private List<AudioClip> soundClips; // Inneholder alle lydklipp
    private FileInfo[] soundFiles; // Midlertidig array
    private List<string> validExtensions = new List<string> { ".wav" }; //Foreløpig bare 1 godkjent fil ext.

	private AudioSource mainTheme; //Hente inn kamera siden den har hoved musikken
	public AudioClip bumpSound;

    void Start()
    {
        if (Application.isEditor) soundDir = "Assets/Sounds"; // bytte lyd dir når man bruker unity editor
        soundClips = new List<AudioClip>();
        loadSoundFiles();
    }

	void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		mainTheme = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource> ();
	}

    private void loadSoundFiles()
    {
        var info = new DirectoryInfo(soundDir);
        soundFiles = info.GetFiles()
            .Where(f => isSoundFile(f.Name))
            .ToArray();

        foreach (var s in soundFiles)
        {
            StartCoroutine(LoadFile(s.FullName));
        }
    }

    IEnumerator LoadFile(string path)
    {
        WWW www = new WWW("file://" + path);

        AudioClip clip = www.GetAudioClip(false);
        while (!clip.isReadyToPlay) 
            yield return www;

        clip.name = Path.GetFileName(path);
        soundClips.Add(clip);
    }

    private bool isSoundFile(string filename)
    {
        return validExtensions.Contains(Path.GetExtension(filename));
    }

    public void playSound(AudioClip sound, Vector3 vector, float volume) {
        AudioSource.PlayClipAtPoint(sound, vector, volume);
    }

	public void playSound(AudioClip sound, Vector3 vector) {
        playSound(sound, vector, 1f);
	}

    public void playClipAt(string name, Vector3 vector, float volume = 1f)
    {
        foreach (AudioClip c in soundClips)
        {
            if (c.name == name)
            {
                playSound(c, vector, volume);
                break;
            }
        }
    }

    public void playClip(string name)
    {
        playClipAt(name, new Vector3(GM.instance.getX(), GM.instance.getY(), 0));
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class soundController : MonoBehaviour {

	public static soundController instance = null;

    private string soundDir = "./Sounds";
    private List<AudioClip> soundClips;
    private FileInfo[] soundFiles;
    private List<string> validExtensions = new List<string> { ".wav" };

	private AudioSource mainTheme;
	public AudioClip bumpSound;

    void Start()
    {
        if (Application.isEditor) soundDir = "Assets/Sounds";
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

	public void playSound(AudioClip sound) {
		AudioSource.PlayClipAtPoint(sound, new Vector3(GM.instance.getX(), GM.instance.getY (), 0));
	}

    public void playClip(string name)
    {
        foreach (AudioClip c in soundClips)
        {
            if (c.name == name)
            {
                playSound(c);
                break;
            }
        }
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

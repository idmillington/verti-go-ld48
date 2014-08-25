using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	private static MusicManager instance;

	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			AudioClip myClip = gameObject.GetComponent<AudioSource>().clip;
			AudioClip playClip = instance.gameObject.GetComponent<AudioSource>().clip;
			if (myClip != playClip) {
				DestroyObject(instance.gameObject);
				instance = this;
				DontDestroyOnLoad(this);
			} else {
				DestroyObject(gameObject);
			}
		}
	}
}

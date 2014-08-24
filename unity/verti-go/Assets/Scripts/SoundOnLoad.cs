using UnityEngine;
using System.Collections;

public class SoundOnLoad : MonoBehaviour {
	public AudioClip loadSound;

	void Start () {
		if (loadSound) AudioSource.PlayClipAtPoint(loadSound, transform.position);
	}
}

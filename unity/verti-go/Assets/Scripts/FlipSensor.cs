using UnityEngine;
using System.Collections;

public class FlipSensor : MonoBehaviour {
	private WorldFlipper flipper;
	private GameObject player;

	public AudioClip flipSound;
	
	void Start () {
		flipper = GameObject.Find("World").GetComponent<WorldFlipper>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			flipper.Flip(gameObject);

			if (flipSound) AudioSource.PlayClipAtPoint(flipSound, transform.position);
		}
	}
}

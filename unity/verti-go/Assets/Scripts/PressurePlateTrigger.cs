using UnityEngine;
using System.Collections;

public class PressurePlateTrigger : MonoBehaviour {
	public AudioClip triggerSound;
	public GameObject platform;

	private GameObject player;
	private PlatformTurn platformTurn;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		platformTurn = platform.GetComponent<PlatformTurn>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			if (triggerSound) AudioSource.PlayClipAtPoint(triggerSound, transform.position);
			platformTurn.NextFlip();
		}
	}
}

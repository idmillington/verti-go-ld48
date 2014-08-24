using UnityEngine;
using System.Collections;

public class DoorSensor : MonoBehaviour {
	public AudioClip triggerSound;

	private GameObject player;
	private DoorOpen[] doorsToOpen;
	
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");

		doorsToOpen = transform.parent.gameObject.GetComponentsInChildren<DoorOpen>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			if (triggerSound) AudioSource.PlayClipAtPoint(triggerSound, transform.position);
			foreach (DoorOpen doorToOpen in doorsToOpen) {
				doorToOpen.Open();
			}
		}
	}
}

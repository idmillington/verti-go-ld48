using UnityEngine;
using System.Collections;

public class DoorSensor : MonoBehaviour {
	public AudioClip triggerSound;

	private GameObject player;
	private DoorOpen[] doorsToOpen;
	private bool opened;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");

		doorsToOpen = transform.parent.gameObject.GetComponentsInChildren<DoorOpen>();
		opened = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (opened) return;

		if (other.gameObject == player) {
			if (triggerSound) AudioSource.PlayClipAtPoint(triggerSound, transform.position);
			foreach (DoorOpen doorToOpen in doorsToOpen) {
				doorToOpen.Open();
			}
			opened = true;
		}
	}
}

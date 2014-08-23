using UnityEngine;
using System.Collections;

public class PickupPickup : MonoBehaviour {
	public AudioClip grabSound;
	public int points = 10;
	
	private GameObject player;
	private Score score;
	
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		score = player.GetComponent<Score>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			if (grabSound) AudioSource.PlayClipAtPoint(grabSound, transform.position);
			score.AddPoints(points);
			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	public AudioClip killSound;

	private GameObject player;
	private Score score;
	
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		score = player.GetComponent<Score>();
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player) {
			if (killSound) AudioSource.PlayClipAtPoint(killSound, transform.position);
			score.Lose();
		}
	}
}

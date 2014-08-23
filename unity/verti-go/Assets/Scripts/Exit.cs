using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public AudioClip exitSound;
	public AudioClip pointDepletionSound;
	public AudioClip pointsAllGoneSound;

	public float maxBonus = 100.0f;
	public float bonusDepletionSpeed = 0.5f;

	private TextMesh indicator;

	private GameObject player;
	private Score score;
	private float bonus;
	private int bonusPoints;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		score = player.GetComponent<Score>();

		indicator = transform.FindChild("Indicator").GetComponent<TextMesh>();

		bonus = maxBonus;
		bonusPoints = (int)bonus;
		UpdateIndicator();
	}

	void UpdateIndicator() {
		System.String text = System.String.Format("{0}", bonusPoints);
		indicator.text = text;
	}

	void Update() {
		bonus -= Time.deltaTime * bonusDepletionSpeed;
		if (bonus < 0) bonus = 0;

		int newBonusPoints = (int)bonus;
		if (newBonusPoints != bonusPoints) {
			// Sound effects for point depletion or exhaustion.
			if (bonusPoints == 0) {
				if (pointsAllGoneSound) AudioSource.PlayClipAtPoint(pointsAllGoneSound, transform.position);
			} else {
				if (pointDepletionSound) AudioSource.PlayClipAtPoint(pointDepletionSound, transform.position);
			}

			// Update indicator
			UpdateIndicator();
		}
		bonusPoints = newBonusPoints;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			if (exitSound) AudioSource.PlayClipAtPoint(exitSound, transform.position);
			score.AddPoints(bonusPoints);
			score.Win();
		}
	}
}

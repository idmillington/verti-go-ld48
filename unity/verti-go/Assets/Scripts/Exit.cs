using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public AudioClip pointDepletionSound;
	public AudioClip pointsAllGoneSound;

	public float maxBonus = 100.0f;
	public float bonusDepletionSpeed = 0.5f;

	private TextMesh indicator;

	private GameObject player;
	private Score score;
	private float bonus;
	private int bonusPoints;

	private float timeToExit;
	private bool exiting;

	void Start() {
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
		if (exiting) UpdateExit();
		else UpdateBonus();
	}

	void UpdateExit() {
		timeToExit -= Time.deltaTime;
		if (timeToExit <= 0.0f) {
			score.Win();
		}
	}

	void UpdateBonus() {
		bonus -= Time.deltaTime * bonusDepletionSpeed;
		if (bonus <= 0.0f) bonus = 0.0f;

		int newBonusPoints = (int)bonus;
		if (newBonusPoints != bonusPoints) {
			// Sound effects for point depletion or exhaustion.
			if (newBonusPoints == 0.0f) {
				if (pointsAllGoneSound) AudioSource.PlayClipAtPoint(pointsAllGoneSound, transform.position);
			} else {
				if (pointDepletionSound) AudioSource.PlayClipAtPoint(pointDepletionSound, transform.position);
			}

			// Update indicator
			bonusPoints = newBonusPoints;
			UpdateIndicator();
		} else {
			bonusPoints = newBonusPoints;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			score.AddPoints(bonusPoints);
			exiting = true;
			timeToExit = 0.0f;
		}
	}
}

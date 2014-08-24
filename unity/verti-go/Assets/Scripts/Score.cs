using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public AudioClip loseSound;
	public AudioClip winSound;

	public System.String nextLevel = "Game Won";
	public bool viaLoadingScreen = true;

	public bool zeroScore = false;
	public GUIText scoreDisplay;

	private int score;

	// Use this for initialization
	void Awake() {
		if (zeroScore) {
			score = 0;
			UpdateScore();
		} else {
			score = PlayerPrefs.GetInt("Score", 0);
		}
	}

	public void AddPoints(int points) {
		score += points;
		UpdateScore();
	}

	void UpdateScore() {
		scoreDisplay.text = System.String.Format("{0}", score);
		PlayerPrefs.SetInt("Score", score);
		if (score > PlayerPrefs.GetInt("Best Score", 0)) {
			PlayerPrefs.SetInt("Best Score", score);
		}
	}

	public void Win() {
		if (winSound) AudioSource.PlayClipAtPoint(winSound, transform.position);
		LoadLevelUtils.LoadLevel(nextLevel, viaLoadingScreen);
	}

	public void Lose() {
		if (loseSound) AudioSource.PlayClipAtPoint(loseSound, transform.position);
		LoadLevelUtils.LoadLevel("Game Over", false);
	}

}

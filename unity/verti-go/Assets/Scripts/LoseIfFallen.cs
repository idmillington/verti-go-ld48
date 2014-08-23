using UnityEngine;
using System.Collections;

public class LoseIfFallen : MonoBehaviour {
	public float lowerLimit = -25.0f;

	private Score score;

	void Start () {
		score = gameObject.GetComponent<Score>();
	}
	
	void Update () {
		if (transform.position.y < lowerLimit) {
			score.Lose();
		}
	}
}

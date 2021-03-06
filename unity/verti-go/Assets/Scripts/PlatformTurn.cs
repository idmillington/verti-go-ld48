﻿using UnityEngine;
using System.Collections;

public class PlatformTurn : MonoBehaviour {
	public float turnSpeed = 36.0f;

	private float currentAngle;
	private float targetAngle;
	private AudioSource turnAudio;

	// Use this for initialization
	void Start () {
		currentAngle = targetAngle = 0.0f;
		turnAudio = gameObject.GetComponent<AudioSource>();
	}

	public void NextFlip() {
		targetAngle += 180.0f;
		turnAudio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		float newAngle = currentAngle + turnSpeed * Time.deltaTime;
		if (newAngle > targetAngle) {
			newAngle = targetAngle;
			audio.Stop();
		}
		float amtToRotate = newAngle - currentAngle;

		Vector3 rotation = new Vector3(amtToRotate, 0.0f, 0.0f);
		transform.Rotate(rotation);

		currentAngle = newAngle;
	}
}

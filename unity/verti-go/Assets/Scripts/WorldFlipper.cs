using UnityEngine;
using System.Collections;

public class WorldFlipper : MonoBehaviour {
	public float turnSpeed = 90.0f;

	private float targetAngle = 180.0f;

	private GameObject flipSensor;
	private float currentAngle;
	private bool flipping;

	// Use this for initialization
	void Start () {
		flipping = false;
	}

	public void Flip(GameObject sensorObject) {
		if (flipping) return;
		flipSensor = sensorObject;
		flipping = true;
		currentAngle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!flipping) return;

		float newAngle = currentAngle + turnSpeed * Time.deltaTime;
		if (newAngle >= targetAngle) newAngle = targetAngle;
		float amtToRotate = newAngle - currentAngle;

		// Flip the world
		Vector3 origin = flipSensor.transform.position;
		transform.RotateAround(origin, Vector3.forward, amtToRotate);
		// Flip additional flippable things
		GameObject[] additionalFlips = GameObject.FindGameObjectsWithTag("AdditionalFlip");
		foreach (GameObject additionalFlip in additionalFlips) {
			if (additionalFlip != flipSensor) {
				additionalFlip.transform.RotateAround(origin, Vector3.forward, amtToRotate);
			}
		}

		currentAngle = newAngle;
		if (currentAngle >= targetAngle) {
			flipping = false;
		}
	}
}

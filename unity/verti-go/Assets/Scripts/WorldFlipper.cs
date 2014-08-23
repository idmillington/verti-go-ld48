using UnityEngine;
using System.Collections;

public class WorldFlipper : MonoBehaviour {
	public float turnSpeed = 90.0f;

	private float targetAngle = 180.0f;

	private Vector3 flipAbout;
	private float currentAngle;
	private bool flipping;

	// Use this for initialization
	void Start () {
		flipping = false;
	}

	public void Flip(Vector3 newOrigin) {
		if (flipping) return;
		flipAbout = newOrigin;
		flipping = true;
		currentAngle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!flipping) return;

		float newAngle = currentAngle + turnSpeed * Time.deltaTime;
		if (newAngle >= targetAngle) newAngle = targetAngle;
		float amtToRotate = newAngle - currentAngle;
		
		transform.RotateAround(flipAbout, Vector3.forward, amtToRotate);
		
		currentAngle = newAngle;
		if (currentAngle >= targetAngle) {
			flipping = false;
		}
	}
}

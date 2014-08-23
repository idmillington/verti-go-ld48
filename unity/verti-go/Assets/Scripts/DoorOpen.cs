using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {
	public float turnSpeed = 90.0f;
	public float openAngle = 90.0f;

	private float currentAngle;
	private float targetAngle;
	
	// Use this for initialization
	void Start () {
		currentAngle = targetAngle = 0.0f;
	}
	
	public void Open() {
		targetAngle = openAngle;
	}
	
	// Update is called once per frame
	void Update () {
		float newAngle;
		if (targetAngle > currentAngle) {
			newAngle = currentAngle + turnSpeed * Time.deltaTime;
			if (newAngle > targetAngle) newAngle = targetAngle;
		} else if (targetAngle < currentAngle) {
			newAngle = currentAngle - turnSpeed * Time.deltaTime;
			if (newAngle < targetAngle) newAngle = targetAngle;
		} else {
			return;
		}
		float amtToRotate = newAngle - currentAngle;

		Vector3 rotation = new Vector3(0.0F, amtToRotate, 0.0f);
		transform.Rotate(rotation);
		
		currentAngle = newAngle;
	}
}

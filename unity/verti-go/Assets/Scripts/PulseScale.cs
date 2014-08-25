using UnityEngine;
using System.Collections;

public class PulseScale : MonoBehaviour {
	public float maxScale = 0.95f;
	public float minScale = 1.05f;
	public float pulseSpeed = 3.0f;

	private float pulseAngle;
	private Vector3 initialScale;

	void Start() {
		initialScale = transform.localScale;
	}

	void Update () {
		pulseAngle += Time.deltaTime * pulseSpeed * Mathf.PI * 0.5f;
		float scaleAmt = Mathf.Sin(pulseAngle);
		scaleAmt = minScale + (maxScale - minScale) * scaleAmt;
		transform.localScale = initialScale * scaleAmt;
	}
}

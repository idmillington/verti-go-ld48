using UnityEngine;
using System.Collections;

public class BobAndRotate : MonoBehaviour {
	public float rotateSpeed = 90f;
	public float bobAmount = 0.25f;
	public float bobSpeed = 45f;
	
	private Vector3 origin;
	private float bobOffset;
	
	void Awake() {
		bobOffset = Random.value * 360f / bobSpeed;			
		origin = transform.localPosition;
	}
	
	void Update () {
		transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
		float theta = (Time.time + bobOffset) * bobSpeed * Mathf.PI / 180f;
		transform.localPosition = origin + new Vector3(0, Mathf.Sin(theta) * bobAmount, 0);
	}
}

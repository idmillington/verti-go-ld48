using UnityEngine;
using System.Collections;

public class ConstantPlatformMovement : MonoBehaviour {
	public float turnSpeed = 36.0f;
	public Vector3 turnAxis = new Vector3(1, 0, 0);

	// Update is called once per frame
	void Update () {
		Vector3 rotation = turnSpeed * Time.deltaTime * turnAxis;
		transform.Rotate(rotation);
	}
}

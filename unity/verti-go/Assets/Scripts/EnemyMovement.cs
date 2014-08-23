using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public float distanceFromEnd = 0.5f;
	public float moveSpeed = 2.0f;

	private Vector3 start;
	private Vector3 end;
	private Transform block;
	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {	
		block = transform.FindChild("Enemy");
		start = block.localPosition;
		end = transform.FindChild("End Point").localPosition;
		currentTarget = end;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = block.localPosition;
		if ((currentPosition - currentTarget).magnitude < distanceFromEnd) {
			if (currentTarget == end) {
				currentTarget = start;
			} else {
				currentTarget = end;
			}
		}

		Vector3 newPosition = Vector3.Lerp(block.localPosition, currentTarget, Time.deltaTime * moveSpeed);
		block.localPosition = newPosition;
	}
}

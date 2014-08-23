using UnityEngine;
using System.Collections;

public class FlipSensor : MonoBehaviour {
	private WorldFlipper flipper;
	private GameObject player;

	void Start () {
		flipper = GameObject.Find("World").GetComponent<WorldFlipper>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			flipper.Flip(transform.position);
		}
	}
}

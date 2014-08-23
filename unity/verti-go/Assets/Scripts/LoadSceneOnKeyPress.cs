using UnityEngine;
using System.Collections;

public class LoadSceneOnKeyPress : MonoBehaviour {
	public System.String levelToLoad = "Level One";

	void Update () {
		if (Input.GetButton("Jump")) {
			Application.LoadLevel(levelToLoad);
		}
	}
}

using UnityEngine;
using System.Collections;

public class LoadSceneOnKeyPress : MonoBehaviour {
	public System.String levelToLoad = "Level One";
	public bool viaLoadingScreen = true;

	void Update () {
		if (Input.GetButton("Jump")) {
			LoadLevelUtils.LoadLevel(levelToLoad, viaLoadingScreen);
		}
	}
}

using UnityEngine;
using System.Collections;

public class LoadNextLevelOnKeyPress : MonoBehaviour {
	public GUIText levelNameDisplay;

	void Start() {
		if (levelNameDisplay) {
			levelNameDisplay.text = PlayerPrefs.GetString("Next Level");
		}
	}

	void Update () {
		if (Input.GetButton("Jump")) {
			System.String levelToLoad = PlayerPrefs.GetString("Next Level");
			LoadLevelUtils.LoadLevel(levelToLoad, true);
		}
	}
}

using UnityEngine;
using System.Collections;

public class LoadSceneRightAway : MonoBehaviour {
	void Start () {
		System.String levelToLoad;
		if (PlayerPrefs.HasKey("Next Level")) {
			levelToLoad = PlayerPrefs.GetString("Next Level");
			PlayerPrefs.DeleteKey("Next Level");
		} else {
			levelToLoad = "Start";
		}
		Application.LoadLevel(levelToLoad);
	}
}

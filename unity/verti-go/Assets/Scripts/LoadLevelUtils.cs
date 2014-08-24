using UnityEngine;
using System.Collections;

public class LoadLevelUtils {
	public static void LoadLevel(System.String levelToLoad, bool viaLoadingScreen) {
		if (viaLoadingScreen) {
			PlayerPrefs.SetString("Next Level", levelToLoad);
			Application.LoadLevel("Loading");
		} else {
			Application.LoadLevel(levelToLoad);
		}
	}
}

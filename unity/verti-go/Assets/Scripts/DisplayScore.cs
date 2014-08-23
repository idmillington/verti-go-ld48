using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour {
	public System.String scoreType = "Score";

	void Start () {
		int score = PlayerPrefs.GetInt(scoreType, 0);
		gameObject.GetComponent<GUIText>().text = System.String.Format("{0}", score);
	}
}

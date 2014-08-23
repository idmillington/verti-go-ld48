using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int score;
	public Texture logo;

	// Use this for initialization
	void Start () {
		score = 0;
	}

	public void AddPoints(int points) {
		score += points;
	}

	public void Win() {
		Debug.Log("Won");
	}

	public void Lose() {
		Debug.Log("Lost");
	}

	void OnGUI() {
		GUI.skin.box.fontSize = GUI.skin.label.fontSize = 20;
		GUIStyle noborderStyle = new GUIStyle(GUI.skin.label);
		noborderStyle.border = new RectOffset(0, 0, 0, 0);
		noborderStyle.margin = new RectOffset(0, 0, 0, 0);
		
		GUI.Box(new Rect(20, 20, 150, 30), "SCORE: "+score);

		int logoHeight = 40;
		int logoWidth = logoHeight * 4;
		GUI.Box(new Rect(Screen.width-logoWidth, 20, logoWidth, logoHeight), logo, noborderStyle);
	}
}

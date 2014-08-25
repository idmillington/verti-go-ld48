using UnityEngine;
using System.Collections;

public class ZeroScore : MonoBehaviour {
	void Start () {
		PlayerPrefs.SetInt("Score", 0);	
	}
}

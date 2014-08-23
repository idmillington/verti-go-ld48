using UnityEngine;
using System.Collections;

public class DisplayLevelName : MonoBehaviour {

	void Start () {
		GetComponent<GUIText>().text = Application.loadedLevelName;
	}
}

using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetTouch(0).phase == TouchPhase.Began) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}

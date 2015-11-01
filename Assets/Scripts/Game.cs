using UnityEngine;
using System.Collections;

public static class Game : System.Object {

	public static void Win() {
		Debug.Log ("Win!");
		Transform t = GameObject.Instantiate<Transform>(Resources.Load<Transform>("Win"));
		User user = GameObject.FindObjectOfType<User> ();
		user.isAlive = false;
		t.parent = user.transform;
		t.localPosition = new Vector3 (0, 0, -3);
	}

	public static void Lose() {
		Debug.Log ("Lose :'(");
		Transform t = GameObject.Instantiate<Transform>(Resources.Load<Transform>("Lose"));
		User user = GameObject.FindObjectOfType<User> ();
		user.isAlive = false;
		t.parent = user.transform;
		t.localPosition = new Vector3 (0, 0, -3);
	}

}

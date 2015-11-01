using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	User user;
	Vector2 currentDirection = Vector2.zero;

	/*Vector2[] possibleMovements = new[] {
		new Vector2(-1,-1), new Vector2( 0,-1), new Vector2( 1,-1),
	    new Vector2(-1, 0),                     new Vector2( 1, 0),
		new Vector2(-1, 1), new Vector2( 0, 1), new Vector2( 1, 1)
	};*/

	Vector2[] possibleMovements = new[] {
		                    new Vector2( 0,-1),
	    new Vector2(-1, 0),                     new Vector2( 1, 0),
		                    new Vector2( 0, 1)
	};

	// Use this for initialization
	void Start () {
		user = FindObjectOfType<User> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.GetComponent<User> ()) {
			Game.Lose();
		}
	}

	public void Move() {
		// Check if we can go to current dir
		if (currentDirection != Vector2.zero) {
			if (!Physics.Linecast(transform.position, transform.position + (Vector3)currentDirection, LayerMask.NameToLayer("wall"))) {
				transform.Translate(currentDirection);
				return;
			}
		}

		// Check the next dir
		float closest = Mathf.Infinity;
		Vector2 move = Vector2.zero;
		foreach (Vector2 movement in possibleMovements) {
			// Cannot change 180 degrees
			if (movement == -currentDirection) continue;

			// Cannot go this way
			if (Physics.Linecast(transform.position, transform.position + (Vector3)movement, 1 << LayerMask.NameToLayer("Wall"))) continue;

			float currDistance = ((Vector2)user.transform.position - ((Vector2)transform.position + movement)).SqrMagnitude();
			if (currDistance < closest) {
				move = movement;
				closest = currDistance;
			}
		}

		currentDirection = move;
		transform.Translate (move);
	}
}

using UnityEngine;
using System.Collections;

public class User : MonoBehaviour {

	public enum SwipeDirection {
		Up,
		Down,
		Right,
		Left,
		None
	}

	void Start() {
	}

	// Update is called once per frame
	void Update () {
		SwipeDirection currSwipeDir = GetCurrentSwipeDirection ();
		if (currSwipeDir != SwipeDirection.None) {
			Vector2 move = Vector2.zero;
			switch(currSwipeDir) {
				case SwipeDirection.Down:
					move = Vector2.down;
					break;
				case SwipeDirection.Up:
					move = Vector2.up;
					break;
				case SwipeDirection.Left:
					move = Vector2.left;
					break;
				case SwipeDirection.Right:
					move = Vector2.right;
					break;
			}

			this.transform.Translate(move);
			
			foreach (Enemy enemy in FindObjectsOfType<Enemy>()) {
				enemy.Move();
			}
		}
	}

	SwipeDirection GetCurrentSwipeDirection() {
		if (Input.GetKeyDown(KeyCode.UpArrow)) return SwipeDirection.Up;
		if (Input.GetKeyDown(KeyCode.DownArrow)) return SwipeDirection.Down;
		if (Input.GetKeyDown(KeyCode.LeftArrow)) return SwipeDirection.Left;
		if (Input.GetKeyDown(KeyCode.RightArrow)) return SwipeDirection.Right;

		if (Input.touchCount == 0) return SwipeDirection.None;

		Touch touch = Input.GetTouch(0);

		if (touch.phase != TouchPhase.Ended) return SwipeDirection.None;

		if (Mathf.Abs (touch.deltaPosition.x) > Mathf.Abs (touch.deltaPosition.y)) {
			return touch.deltaPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
		} else {
			return touch.deltaPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
		}
	}


}

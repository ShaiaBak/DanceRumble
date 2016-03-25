using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum SwipeDirection {
    None = 0,
    Left = 1,
    Right = 2,
    Up = 3,
    Down = 4
}

public class SwipeDetection : MonoBehaviour {

    private static SwipeDetection instance;
    public static SwipeDetection Instance { get { return instance; } }

    // Direction is a PROPERTY
    public SwipeDirection UserDirection { set; get; }
	public ScoreHandler scoreHandler;
    public float swipeResistanceX;
    public float swipeResistanceY;
    public Text dirText;

	private Vector3 touchPosition;

    void Start() {
		scoreHandler = gameObject.AddComponent<ScoreHandler>();
        instance = this;
    }

    public void Update() {
        UserDirection = SwipeDirection.None;

        // when mouse left clicks
        if (Input.GetMouseButtonDown(0)) {
            // the touch position is moved to where the mouse position is
            touchPosition = Input.mousePosition;
        }

        // when mouse is released
        if (Input.GetMouseButtonUp(0)) {
            // deltaSwipe is the difference to where you touched and you released
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            // check how far / direction
            if (Mathf.Abs(deltaSwipe.x) > swipeResistanceX) {
                // Swipe on the X axis
                UserDirection |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left; // if x is smaller than 0, swipdirection is right, else Left
                if (UserDirection == SwipeDirection.Left) {
					dirText.text = "Player Direction:\n" + UserDirection;
                } else if (UserDirection == SwipeDirection.Right) {
					dirText.text = "Player Direction:\n" + UserDirection;
                }
            }

            if (Mathf.Abs(deltaSwipe.y) > swipeResistanceY) {
                // Swipe on the Y axis
                UserDirection |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
                if (UserDirection == SwipeDirection.Up) {
					dirText.text = "Player Direction:\n" + UserDirection;
                } else if (UserDirection == SwipeDirection.Down) {
					dirText.text = "Player Direction:\n" + UserDirection;
                }
            }
			scoreHandler.compareDir();
        }
    }

    public bool IsSwiping(SwipeDirection dir) {
        return (UserDirection & dir) == dir;
    }
}
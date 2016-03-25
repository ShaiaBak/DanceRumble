using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum SwipeDirection {
    None = 0,
    Left = 1,
    Right = 2,
    Up = 4,
    Down = 8
}

public class SwipeDetection : MonoBehaviour {

    private static SwipeDetection instance;
    public static SwipeDetection Instance { get { return instance; } }

    public SwipeDirection userDirection { set; get; } // SwipeDirection is a PROPERTY
    public ScoreManager scoreManager;
    public float swipeResistanceX;
    public float swipeResistanceY;
    public Text dirText;

	private Vector3 touchPosition;

    void Start() {
		scoreManager = GetComponent<ScoreManager>();
        instance = this;
    }

    public void Update() {
        userDirection = SwipeDirection.None;

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
                userDirection |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left; // if x is smaller than 0, swipdirection is right, else Left
                if (userDirection == SwipeDirection.Left) {
					dirText.text = "Player Direction:\n" + userDirection;
                } else if (userDirection == SwipeDirection.Right) {
					dirText.text = "Player Direction:\n" + userDirection;
                }
            }

            if (Mathf.Abs(deltaSwipe.y) > swipeResistanceY) {
                // Swipe on the Y axis
                userDirection |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
                if (userDirection == SwipeDirection.Up) {
					dirText.text = "Player Direction:\n" + userDirection;
                } else if (userDirection == SwipeDirection.Down) {
					dirText.text = "Player Direction:\n" + userDirection;
                }
            }
			scoreManager.compareDir();
        }
    }

    public bool IsSwiping(SwipeDirection dir) {
        return (userDirection & dir) == dir;
    }
}
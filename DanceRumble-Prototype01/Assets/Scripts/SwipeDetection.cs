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
    public SwipeDirection Direction { set; get; }

    private Vector3 touchPosition;
    public float swipeResistanceX;
    public float swipeResistanceY;
    public Text dirText;

    private void Start() {
        instance = this;
    }

    private void Update() {
        Direction = SwipeDirection.None;

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
                Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left; // if x is smaller than 0, swipdirection is right, else Left
                if (Direction == SwipeDirection.Left) {
                    dirText.text = "Player Direction:\nLeft";
                } else if (Direction == SwipeDirection.Right) {
                    dirText.text = "Player Direction:\nRight";
                }
            }

            if (Mathf.Abs(deltaSwipe.y) > swipeResistanceY) {
                // Swipe on the Y axis
                Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
                if (Direction == SwipeDirection.Up) {
                    dirText.text = "Player Direction:\nUp";
                } else if (Direction == SwipeDirection.Down) {
                    dirText.text = "Player Direction:\nDown";
                }
            }
        }
    }

    public bool IsSwiping(SwipeDirection dir) {
        return (Direction & dir) == dir;
    }
}
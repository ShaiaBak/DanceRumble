using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int score;
    public Text scoreTxt;

    public SwipeDetection userSwipeDetection;
    public GenerateDirection genDirectionScript;

    void Start() {
        userSwipeDetection = GetComponent<SwipeDetection>();
        genDirectionScript = GetComponent<GenerateDirection>();
        score = 0;
        //Debug.Log("Score: " + scoreTxt);
        UpdateScoreText();
    }

    public void compareDir() {
        // compare directions, and see if they are the same.
        // this is lazy. fix this shitttt
        if (SwipeDetection.Instance.IsSwiping(SwipeDirection.Right) && GenerateDirection.Instance.GenSwipe(generatedDir.Right)) {
            score++;
        } else if (SwipeDetection.Instance.IsSwiping(SwipeDirection.Left) && GenerateDirection.Instance.GenSwipe(generatedDir.Left)) {
            score++;
        } else if (SwipeDetection.Instance.IsSwiping(SwipeDirection.Down) && GenerateDirection.Instance.GenSwipe(generatedDir.Down)) {
            score++;
        } else if (SwipeDetection.Instance.IsSwiping(SwipeDirection.Up) && GenerateDirection.Instance.GenSwipe(generatedDir.Up)) {
            score++;
        } else {
            score--;
        }
        //Debug.Log("Player Dir: " + SwipeDetection.Instance.IsSwiping(SwipeDirection.Left));
        //Debug.Log("Gen Dir: " + genDirectionScript.genCurrDirection);
        //Debug.Log("Player Dir: " + userSwipeDetection.userDirection.GetType());
        //Debug.Log("Gen Dir: " + genDirectionScript.genCurrDirection.GetType());
        UpdateScoreText();
    }

    public void UpdateScoreText() {
        scoreTxt.text = "Score: " + score;
    }
}

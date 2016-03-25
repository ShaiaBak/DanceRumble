using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : MonoBehaviour {
	public int score;
	public Text scoreGuiText;

	public void Start() {
		score = 0;
		updateScoreText();
	}

	public void compareDir() {
		score++;
		updateScoreText();
	}

	public void updateScoreText() {
		scoreGuiText.text = "Score: " + score;
	}
}
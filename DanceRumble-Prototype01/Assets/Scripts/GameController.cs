using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public Camera cam;
    public Text timerText;
	public Text debugText;

    public float timeLeft;

	// Use this for initialization
	void Start () {
	    if(cam == null) {
            cam = Camera.main;
        }
        UpdateTimerText();
		InitDebugText();
    }
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            timeLeft = 0;
        }
        UpdateTimerText();
	}

    void UpdateTimerText() {
        timerText.text = "Time: " + Mathf.RoundToInt(timeLeft);
    }

	void InitDebugText() {
		//debugText.text = "enum Debug\n" + generatedDir;
	}
}
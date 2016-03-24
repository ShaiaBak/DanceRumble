using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum generatedDir {
    Left,
    Right,
    Up,
    Down
}

public class GameController : MonoBehaviour {
    public Camera cam;
    public Text AIDirText;
    public Text timerText;

    public int dirNumber;
    public float waitBeforeStart;
    public float waitBetweenDir;
    public float timeLeft;

	// Use this for initialization
	void Start () {
	    if(cam == null) {
            cam = Camera.main;
        }
        UpdateTimerText();
        StartCoroutine(spawnDirection());
    }
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            timeLeft = 0;
        }
        UpdateTimerText();
	}

    IEnumerator spawnDirection() {
        yield return new WaitForSeconds(waitBeforeStart);
        
        while(timeLeft > 0) {
            dirNumber = Random.Range(1, 5);
            UpdateDirText();
            yield return new WaitForSeconds(waitBetweenDir);
        }
        //yield return new WaitForSeconds(3.0f);
    }

    void UpdateTimerText() {
        timerText.text = "Time: " + Mathf.RoundToInt(timeLeft);
    }

    void UpdateDirText() {
        AIDirText.text = "Game Direction\n" + dirNumber;
    }
}

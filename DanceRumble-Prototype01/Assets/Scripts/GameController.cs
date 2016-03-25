using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum generatedDir {
	None,
	Up,
	Right,
    Down,
	Left
}

public class GameController : MonoBehaviour {
    public Camera cam;
    public Text AIDirText;
    public Text timerText;
	public Text debugText;
	public Text switchNumText;
	public int switchNum = 0;

    public int dirNumber;
    public float waitBeforeStart;
    public float waitBetweenDir;
    public float timeLeft;

	public string genPrevDir; // generated previous direction 
	public generatedDir genCurrDirection { set; get; } // generated current direction

	// Use this for initialization
	void Start () {
	    if(cam == null) {
            cam = Camera.main;
        }
        UpdateTimerText();
		InitDebugText();
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
			gameDirectionHandler ();
            UpdateDirText();
            yield return new WaitForSeconds(waitBetweenDir);
        }
        //yield return new WaitForSeconds(3.0f);
    }

	void gameDirectionHandler() {
		genCurrDirection =  generatedDir.None; 
		switch (dirNumber) {
		case 1:
			genCurrDirection = generatedDir.Up;
			break;
		case 2:
			genCurrDirection = generatedDir.Right;
			break;
		case 3:
			genCurrDirection = generatedDir.Down;
			break;
		case 4:
			genCurrDirection = generatedDir.Left;
			break;
		}
	}

    void UpdateTimerText() {
        timerText.text = "Time: " + Mathf.RoundToInt(timeLeft);
    }

    void UpdateDirText() {
		switchNum++;
		AIDirText.text = "Game Direction\n" + genCurrDirection;
		switchNumText.text = "Switch: " + switchNum;
    }

	void InitDebugText() {
		//debugText.text = "enum Debug\n" + generatedDir;
	}
}
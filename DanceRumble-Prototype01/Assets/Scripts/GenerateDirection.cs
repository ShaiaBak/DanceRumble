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

public class GenerateDirection : MonoBehaviour {

    public GameController gameController;

    private static GenerateDirection instance;
    public static GenerateDirection Instance { get { return instance; } }

    public int dirNumber;
    public float waitBeforeStart;
    public float waitBetweenDir;

    public Text switchNumText;
    public Text AIDirText;
    public int switchNum = 0;

    public string genPrevDir; // generated previous direction 
    public generatedDir genCurrDirection { set; get; } // generated current direction

    // Use this for initialization
    void Start () {
        instance = this;
        gameController = GetComponent<GameController>();
        StartCoroutine(spawnDirection());
    }

    IEnumerator spawnDirection() {
        yield return new WaitForSeconds(waitBeforeStart);

        while (gameController.timeLeft > 0) {
            dirNumber = Random.Range(1, 5);
            gameDirectionHandler();
            UpdateDirText();
            yield return new WaitForSeconds(waitBetweenDir);
        }
        //yield return new WaitForSeconds(3.0f);
    }

    void gameDirectionHandler() {
        genCurrDirection = generatedDir.None;
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

    public bool GenSwipe(generatedDir dir) {
        return (genCurrDirection & dir) == dir;
    }

    void UpdateDirText() {
        switchNum++;
        AIDirText.text = "Game Direction\n" + genCurrDirection;
        switchNumText.text = "Switch: " + switchNum;
    }
}

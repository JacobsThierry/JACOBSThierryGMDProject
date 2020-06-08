using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreDisplayController : MonoBehaviour
{

private UnityEngine.UI.Text text;
private scoreController score;

public string scoreDisplayText = "Score :";

private void Start() {
    text = GetComponent<UnityEngine.UI.Text>();
    score = GameObject.Find("game").GetComponent<scoreController>();
    displayScore();
}

    private void OnEnable()
    {
        scoreController.scoreUpdated += displayScore;
    }

    private void OnDisable()
    {
        scoreController.scoreUpdated -= displayScore;
    }

    private void displayScore(){
        text.text = scoreDisplayText + score.score.ToString();

    }

}

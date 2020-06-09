using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreController : MonoBehaviour
{


    public int score=0;

    public delegate void scoreDelegate();
    public static event scoreDelegate scoreUpdated;


    private void OnEnable()
    {
        Ship.EnnemyKilled += addPoints;
    }

    private void OnDisable()
    {
        Ship.EnnemyKilled -= addPoints;
    }

    private void addPoints(){
        score+=100;
        if(scoreUpdated != null) scoreUpdated();
    }

    private void OnDestroy() {
        saveSystem.addHighScore(score);
    }

}

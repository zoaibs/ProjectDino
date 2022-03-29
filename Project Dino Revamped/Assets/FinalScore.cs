using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FinalScore : MonoBehaviour
{
    public Text finalScoreText;
    public float finalScore;
    public ScoreManager ScoreScript;
    void Start()
    {
        finalScore = ScoreScript.scoreAmount;
    }
    
    void Update()
    {
        finalScoreText.text = "Your Score: " + (int)finalScore;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public float scoreAmount;
    public float pointsPerSecond;
    float levelOneScore;
    float levelTwoScore;
    float levelThreeScore;
    float totalScore;
    public static ScoreManager Instance;

    //string SceneName = SceneManager.GetActiveScene().name;
    
    //int score = 100;
    // Start is called before the first frame update
    void Awake()
    {
        //string SceneName = SceneManager.GetActiveScene().name;
    }
    void Start()
    {
        //scoreAmount = 1000f;
        pointsPerSecond = -1f;
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {   
       
        if(SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3")
        {  
        
           if(scoreAmount>0){
               scoreAmount += pointsPerSecond * Time.deltaTime;
           } 

            scoreText.text = "Score: " + (int)scoreAmount;
           
           
        }
        if(SceneManager.GetActiveScene().name == "Resolution")
        {
            gameObject.SetActive(false);
        }
        DontDestroyOnLoad(this.gameObject);
       
    }
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] string currentLevel;
    [SerializeField] string nextLevelToNotKillAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == currentLevel || SceneManager.GetActiveScene().name == nextLevelToNotKillAudio)
        {
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);  //this is the first time something worked on the first try hell yeah
        }
    }
}

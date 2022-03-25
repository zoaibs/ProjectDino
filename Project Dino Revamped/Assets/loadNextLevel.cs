using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextLevel : MonoBehaviour
{
    public string LevelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "Archaeologist")
        {
             SceneManager.LoadScene(LevelToLoad);
        }
    }
   
}

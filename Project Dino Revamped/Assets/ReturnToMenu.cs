using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ReturnToMenu : MonoBehaviour
{
    public void TeleportMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
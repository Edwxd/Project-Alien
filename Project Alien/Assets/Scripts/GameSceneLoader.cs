using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainGameScene");
    }
}
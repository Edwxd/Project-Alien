using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Titan"))
        {
            Destroy(gameObject);
            
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("GameOverScene");
            
        }
    }
}
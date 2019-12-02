using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public GameObject player;
    public float resDelay = 1f;

    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;

            Debug.Log("Game Over");
            Invoke("Restart", resDelay);
        }
       
    }

    public void GoodGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;

            Debug.Log("Good Game");
            Invoke("Restart", resDelay);
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

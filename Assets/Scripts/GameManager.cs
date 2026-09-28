using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        // Unfreeze time scale before reloading
        Time.timeScale = 1f;
        // Reload current active scene (Play2)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
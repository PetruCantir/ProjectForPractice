using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public int SceneNumber;
    public void Level()
    {
        SceneManager.LoadScene(SceneNumber);
        Time.timeScale = 1f;
    }
}


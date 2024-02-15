using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject _gameOver;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOver"))
        {
            _gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
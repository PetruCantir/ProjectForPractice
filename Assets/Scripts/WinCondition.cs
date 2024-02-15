using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject youWinPanel;

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            youWinPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            youWinPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}

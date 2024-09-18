using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        if (restartButton == null)
            restartButton = GetComponent<Button>();

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        transform.parent.gameObject.SetActive(false);
    }
}

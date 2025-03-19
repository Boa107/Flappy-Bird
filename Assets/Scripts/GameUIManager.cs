using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public Button quitButton;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public Button retryButton;
    public Button quitButtonGO;

    private bool isPaused = false;

    void Start()
    {
        // Ẩn các nút và panel ban đầu
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);

        // Gán sự kiện cho các nút
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(PauseGame);
        }
        else
        {
            Debug.LogError("PauseButton chưa được gán trong Inspector!");
        }

        if (retryButton != null)
        {
            retryButton.onClick.AddListener(RetryGame);
        }
        else
        {
            Debug.LogError("RetryButton chưa được gán trong Inspector!");
        }

        if (quitButtonGO != null)
        {
            quitButtonGO.onClick.AddListener(QuitToMenu);
        }
        else
        {
            Debug.LogError("QuitButtonGO chưa được gán trong Inspector!");
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void RetryGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void ShowGameOver(int score)
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + score;
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }
}
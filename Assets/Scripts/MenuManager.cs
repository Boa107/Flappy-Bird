using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button playButton;
    public Button scoreButton;
    public Button quitButton;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        scoreButton.onClick.AddListener(ShowScore);
        quitButton.onClick.AddListener(QuitGame);

        // Ẩn scoreText khi khởi động
        scoreText.gameObject.SetActive(false);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    void ShowScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // Lấy điểm cao nhất
        scoreText.text = "High Score: " + highScore;
        scoreText.gameObject.SetActive(true);
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // Log để kiểm tra trong Editor
    }
}
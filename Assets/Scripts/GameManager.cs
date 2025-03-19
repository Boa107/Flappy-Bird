using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private float timer = 0f;

    void Start()
    {
        score = 0; // Reset điểm khi bắt đầu
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            float randomY = Random.Range(-2f, 2f);
            Instantiate(pipePrefab, new Vector3(10f, randomY, 0), Quaternion.identity);
            timer = 0f;
        }
        scoreText.text = "Score: " + score;
    }

    public void AddScore()
    {
        score++;
    }

    public void SaveHighScore()
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
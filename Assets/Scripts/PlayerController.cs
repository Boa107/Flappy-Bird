using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public ParticleSystem rocketSmoke;
    private Rigidbody2D rb;
    private AudioSource jumpAudio;
    private AudioSource deathAudio;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        jumpAudio = audioSources[0];
        deathAudio = audioSources[1];
        if (rocketSmoke == null)
        {
            Debug.LogError("RocketSmoke chưa được gán trong Inspector!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            jumpAudio.Play();
            if (rocketSmoke != null)
            {
                rocketSmoke.Play();
            }
        }

        if (transform.position.y > 5f || transform.position.y < -5f)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Die()
    {
        deathAudio.Play();
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.SaveHighScore();
        FindObjectOfType<GameUIManager>().ShowGameOver(gameManager.score);
        Time.timeScale = 0; // Dừng game khi chết
    }
}
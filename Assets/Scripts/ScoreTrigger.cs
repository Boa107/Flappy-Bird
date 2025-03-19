using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private AudioSource scoreAudio;

    void Start()
    {
        scoreAudio = transform.parent.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().AddScore();
            transform.parent.GetComponent<PipeMovement>().MarkAsPassed();
            scoreAudio.Play();
        }
    }
}
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;
    private bool hasPassed = false;
    private float destroyTimer = 0f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (hasPassed)
        {
            destroyTimer += Time.deltaTime;
            if (destroyTimer >= 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void MarkAsPassed()
    {
        hasPassed = true;
    }
}
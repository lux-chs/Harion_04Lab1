using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftBound = -15f;

    void Update()
    {
        // Move obstacle leftward toward the player
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Destroy obstacle once it leaves the left side of the screen
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
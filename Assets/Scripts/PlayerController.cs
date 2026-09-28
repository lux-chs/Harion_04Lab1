using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement & Jump")]
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isDead = false;

    [Header("UI Reference")]
    public GameObject gameOverPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        // Jump when Spacebar or Up Arrow is pressed and player is on the ground
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detect landing on the sidewalk
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Detect hitting an obstacle
        if (collision.gameObject.CompareTag("Obstacle") && !isDead)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isDead = true;

        // Show Game Over UI
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Freeze game physics and obstacle movement
        Time.timeScale = 0f;
    }
}
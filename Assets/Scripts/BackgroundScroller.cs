using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("Scroll Speed")]
    public float scrollSpeed = 15f; // Match with obstacle speed

    private float spriteWidth;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            // Get actual world-space width considering object scaling
            spriteWidth = sr.bounds.size.x;
        }
        else
        {
            spriteWidth = 17.7f;
        }
    }

    void Update()
    {
        // 1. Move left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 2. Once this sprite has completely slid past the left side of the screen,
        // jump it directly behind the second background (shift forward by 2 full widths)
        if (transform.position.x <= -spriteWidth)
        {
            transform.position += new Vector3(spriteWidth * 2f, 0f, 0f);
        }
    }
}
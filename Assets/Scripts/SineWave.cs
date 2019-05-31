using UnityEngine;

public class SineWave : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3.0f;

    [SerializeField]
    float frequency = 2.0f;

    [SerializeField]
    float magnitude = 1.0f;

    private Vector3 pos;
    private Vector2 left;
    private Renderer rend;
    private Vector2 spriteHalfSize;

    float elapsedTime = 0;

    void Start()
    {
        pos = transform.position;
        left = Camera.main.ViewportToWorldPoint(Vector3.zero);  // Find left screen border
        rend = GetComponent<Renderer>();        // Used to find character sprite size
        spriteHalfSize = rend.bounds.extents;   // Spritesize / 2
    }

    void Update()
    {
        // Check if object left the screen on left side, and destroy it if it has
        if (pos.x < (left.x - spriteHalfSize.x))
        {
            Destroy(gameObject);
        }
        pos -= transform.right * Time.deltaTime * moveSpeed;    // Use += to move the text from left to right instead
        elapsedTime += Time.deltaTime;
        transform.position = pos + (transform.up * Mathf.Sin(elapsedTime * frequency) * magnitude); // use time.time instead of elapsedTime
                                                                                                    // to make them move with same y pos
    }
}

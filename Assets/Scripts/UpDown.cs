using UnityEngine;

public class UpDown : MonoBehaviour
{
    [SerializeField]
    float frequency = 2.0f;

    [SerializeField]
    float magnitude = 1.0f;

    [SerializeField]
    float yPos = 1.0f;

    [SerializeField]
    float elapsedTime = 0f;

    private Vector3 pos;
    private Renderer rend;
    private Vector3 lastPos;

    private void Start()
    {
        pos.y = yPos;
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        pos.y = yPos;
        elapsedTime += Time.deltaTime;
        lastPos = transform.position;
        transform.position = pos + (transform.up * Mathf.Sin(elapsedTime * frequency) * magnitude);

        // Check if the bars are moving up or down
        if (transform.position.y > lastPos.y)
        {
            rend.sortingOrder = 5;  // Move on the front of the picture
        }
        else
        {
            rend.sortingOrder = 3;  // Mone on the back of the picture
        }
    }
}

using UnityEngine;

public class Typewriter : MonoBehaviour
{
    float timeToLive = 5.0f;

    private void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
            Destroy(gameObject);
    }
}

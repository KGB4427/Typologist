using UnityEngine;

public class RectShrinkStep : MonoBehaviour
{
    public RectTransform targetRect;             // Assign this in the Inspector
    public Vector3 targetScale = Vector3.one * 0.5f; // Minimum scale
    public Vector3 shrinkStep = new Vector3(0.1f, 0.1f, 0f); // Amount to shrink per step
    public float shrinkInterval = 0.2f;          // Time between steps (in seconds)

    private float timer = 0f;

    void Update()
    {
        if (targetRect == null) return;

        timer += Time.deltaTime;

        if (timer >= shrinkInterval)
        {
            timer = 0f;

            // Only shrink if not at or below target
            if (targetRect.localScale.x > targetScale.x || targetRect.localScale.y > targetScale.y)
            {
                Vector3 newScale = targetRect.localScale - shrinkStep;

                // Clamp the scale to the target minimum
                newScale.x = Mathf.Max(newScale.x, targetScale.x);
                newScale.y = Mathf.Max(newScale.y, targetScale.y);
                newScale.z = targetRect.localScale.z; // Optional: keep Z the same

                targetRect.localScale = newScale;
            }
        }
    }
}